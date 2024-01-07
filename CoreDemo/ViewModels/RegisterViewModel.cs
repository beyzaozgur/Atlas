using System.ComponentModel.DataAnnotations;

namespace CoreDemo.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Cannot be blank.")]
		public string NameSurname { get; set; }

		[Required(ErrorMessage = "Cannot be blank.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Cannot be blank.")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Passwords do not match.")]
		public string PasswordAgain { get; set; }

		[Required(ErrorMessage = "Cannot be blank.")]
		public string City { get; set; }

		[Required(ErrorMessage = "Cannot be blank.")]
		public IFormFile ImageUrl { get; set; }

	}
}
