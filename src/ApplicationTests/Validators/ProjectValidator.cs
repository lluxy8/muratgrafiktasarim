using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Proje başlığı boş olamaz.")
                .MaximumLength(200).WithMessage("Proje başlığı en fazla 200 karakter olabilir.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Proje açıklaması boş olamaz.")
                .MaximumLength(1000).WithMessage("Proje açıklaması en fazla 1000 karakter olabilir.");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("Proje bir kategoriye ait olmalıdır.");
        }
    }
}
