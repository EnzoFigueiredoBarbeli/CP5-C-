using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição curta é obrigatória")]
        [StringLength(500)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0, 999999.99)]
        public decimal Price { get; set; }

        [Url(ErrorMessage = "URL inválida")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}