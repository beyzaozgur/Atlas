using System.ComponentModel.DataAnnotations;

namespace CoreDemo.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Cannot be blank.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Cannot be blank.")]
		public string Password { get; set; }
	}
}
