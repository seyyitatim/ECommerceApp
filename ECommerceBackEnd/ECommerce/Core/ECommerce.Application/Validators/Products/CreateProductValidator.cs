using ECommerce.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Products>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Lütfen ürün adını boş geçmeyiniz.");
        }
    }
}
