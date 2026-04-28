using GameStoreMVC.Interfaces;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameStoreMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IGameRepositorio _gameRepositorio;

        public AdminController(ILogger<AdminController> logger, IGameRepositorio gameRepositorio)
        {
            _logger = logger;
            _gameRepositorio = gameRepositorio;
        }

        public IActionResult Index()
        {
            
            return View();
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
