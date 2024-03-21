using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class QAValidator : AbstractValidator<QA>
    {
        public QAValidator()
        {
            RuleFor(x => x.Question).NotEmpty().WithMessage("Question boş bırakılamaz.");
            RuleFor(x => x.Question).MaximumLength(200).WithMessage("Question 200 karakterden fazla olamaz.");

            RuleFor(x => x.Answer).NotEmpty().WithMessage("Answer boş bırakılamaz.");
            RuleFor(x => x.Answer).MaximumLength(200).WithMessage("Answer 200 karakterden fazla olamaz.");
        }
    }
}
