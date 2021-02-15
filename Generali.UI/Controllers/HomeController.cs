using Generali.UI.Artifacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF = Generali.UI.SalesWCFReference;

namespace Generali.UI.Controllers
{
    [AuthorizationFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            WCF.Service1Client client = new WCF.Service1Client();
            var result=client.Login(new WCF.UserLoginRequest()
            {
                Password = "123456",
                UserName = "oguz.unlutas"
            });

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}