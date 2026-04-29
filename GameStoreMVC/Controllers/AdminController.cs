using GameStore.Models;
using GameStore.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public AdminController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameRepository.GetAllAsync();
            return View(games);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                await _gameRepository.AddAsync(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null) return NotFound();
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Game game)
        {
            if (id != game.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _gameRepository.UpdateAsync(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null) return NotFound();
            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gameRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}