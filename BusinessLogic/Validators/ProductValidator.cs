using Core.DataObjects.Business.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class ProductValidator : AbstractValidator<AddProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(expression: u => u.Barcode).NotEmpty().MaximumLength(15);
            RuleFor(expression: u => u.CreatedBy).NotEmpty();
            RuleFor(expression: u => u.Description).NotEmpty().MaximumLength(100);
            RuleFor(expression: u => u.ModifiedBy).NotEmpty();
            RuleFor(expression: u => u.ProductCode).NotEmpty();
            RuleFor(expression: u => u.ProductName).NotEmpty();
            RuleFor(expression: u => u.Quantity).NotEmpty();
            RuleFor(expression: u => u.RetailPrice).NotEmpty();
        }
    }
}
