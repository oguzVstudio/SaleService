using BusinessLogic.Validators;
using Core.DataObjects.Business.Requests;
using Core.DataObjects.Business.Responses;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.LogicServices
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserService _userService;
        public UserLoginService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<LoginResult> LoginAsync(UserLoginRequest userLoginRequest)
        {
            var userLoginValidator = new UserLoginRequestValidator();
            var validation = userLoginValidator.Validate(userLoginRequest);
            if (validation.IsValid)
            {
                var user = await _userService.FindByUserNameAsync(userLoginRequest.UserName);
                if (user == null)
                {
                    return new LoginResult()
                    {
                        Success = false,
                        Errors = new string[] { "User doesn't exists" }
                    };
                }
                else
                {
                    return user.Password == userLoginRequest.Password ?
                        new LoginResult()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Id = user.Id,
                        PhoneNumber = user.PhoneNumber,
                        Success = true,
                        UserName = user.UserName
                    }
                    :
                    new LoginResult()
                    {
                        Success = false,
                        Errors = new string[] { "Password is not correct" }
                    };
                }
            }
            else
            {
                return new LoginResult()
                {
                    Success = false,
                    Errors = validation.Errors.Select(u => u.ErrorMessage)
                };
            }
        }
    }
}
