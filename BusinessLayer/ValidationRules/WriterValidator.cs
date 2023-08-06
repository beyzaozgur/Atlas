using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    // fluent validation
	public class WriterValidator: AbstractValidator<Writer>
	{
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			RuleFor(x => x.WriterCity).NotEmpty().WithMessage("Bu alan boş geçilemez!");
			RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Bu alan boş geçilemez!");

			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Ad Soyad 2 karakterden fazla olmalıdır.");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Ad Soyad 50 karakterden az olmalıdır.");

		}
    }
}
