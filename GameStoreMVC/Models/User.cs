using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Nome é obrigatório")]
		[StringLength(100)]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "E-mail é obrigatório")]
		[EmailAddress(ErrorMessage = "E-mail inválido")]
		public string Email { get; set; } = string.Empty;

		[Required]
		public string PasswordHash { get; set; } = string.Empty;

		[Required]
		public string Role { get; set; } = "User"; // Admin or User
	}
}