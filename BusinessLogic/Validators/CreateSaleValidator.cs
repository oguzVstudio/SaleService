using Core.DataObjects.Business.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleValidator()
        {
            RuleFor(expression: x => x.Quantity).NotEmpty();
            RuleFor(expression: x => x.SaleDate).NotEmpty();
            RuleFor(expression: x => x.SalesPrice).NotEmpty();
            RuleFor(expression:x => x.SaleDetails).SetCollectionValidator(new SaleDetailsValidator());
        }
    }
    public class SaleDetailsValidator : AbstractValidator<SaleDetailRequest>
    {
        public SaleDetailsValidator()
        {
            RuleFor(expression: x => x.ProductId).NotEmpty();
            RuleFor(expression: x => x.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(expression: x => x.SalesPrice).GreaterThanOrEqualTo(0);
        }
    }
}
