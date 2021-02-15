using Core.DataObjects.Business.Requests;
using Core.DataObjects.Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.LogicServices
{
    public interface IUserLoginService
    {
        Task<LoginResult> LoginAsync(UserLoginRequest userLoginRequest);
    }
}
