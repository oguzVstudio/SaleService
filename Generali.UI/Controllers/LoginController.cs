using Generali.UI.DataObjects.Internal;
using Generali.UI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF = Generali.UI.SalesWCFReference;

namespace Generali.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    WCF.Service1Client client = new WCF.Service1Client();
                    var result = client.Login(new WCF.UserLoginRequest()
                    {
                        Password = loginModel.Password,
                        UserName = loginModel.UserName
                    });

                    if (result.Success)
                    {
                        Session["User"] = new UserInfo()
                        {
                            Email = result.Email,
                            FirstName = result.FirstName,
                            Id = result.Id,
                            LastName = result.LastName,
                            PhoneNumber = result.PhoneNumber,
                            UserName = result.UserName
                        };

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var errorMessage = result.Errors.FirstOrDefault() == null ? "An error occurred" : result.Errors.FirstOrDefault();
                        
                        throw new Exception(errorMessage);
                    }
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception _ex)
            {
                ModelState.AddModelError("Error", _ex.Message);
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}