using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    // fluent validation
	public class UserValidator: AbstractValidator<User>
	{
        public UserValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			//RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			//RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			//RuleFor(x => x.WriterCity).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			//RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Bu alan boş geçilemez!");

			RuleFor(x => x.NameSurname).MinimumLength(2).WithMessage("Ad Soyad 2 karakterden fazla olmalıdır.");
			RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("Ad Soyad 50 karakterden az olmalıdır.");

		}
    }
}
