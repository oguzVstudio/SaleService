using Core.DataObjects.Business.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(expression: x => x.UserName)
                .NotEmpty();
            RuleFor(expression: x => x.Password)
                .NotEmpty();
        }
    }
}
