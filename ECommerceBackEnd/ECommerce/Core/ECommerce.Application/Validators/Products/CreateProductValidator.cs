using ECommerce.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stock alanını boş geçmeyiniz")
                .Must(s => s >= 0)
                    .WithMessage("Stock bilgisi 0 ya da 0'dan büyük olmalıdır.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen price alanını boş geçmeyiniz")
                .Must(p => p >= 0)
                    .WithMessage("Price bilgisi 0 ya da 0'dan büyük olmalıdır.");
        }
    }
}
