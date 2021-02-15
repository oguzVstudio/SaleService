using BusinessLogic.Services.EntityServices;
using BusinessLogic.Services.LogicServices;
using Core.Interfaces.Services;
using Core.Interfaces.UnitOfWork;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.UnitOfWork;
using GeneraliSaleService.Initialize;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace GeneraliSaleService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.RegisterWcfServices(Assembly.GetExecutingAssembly());
            //dbcontext
            //container.Register<DbContext>(() =>
            //{
            //    return new ApplicationDbContext();
            //});
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);

            //metadata services
            //container.Register<ICustomerTableService, CustomerService>(Lifestyle.Transient);
            
            container.Register<IProductTableService, ProductTableService>(Lifestyle.Transient);
            container.Register<ISaleDetailService, SaleDetailService>(Lifestyle.Transient);
            container.Register<ISalesTableService, SalesTableService>(Lifestyle.Transient);
            
            container.Register<IUserService, UserTableService>(Lifestyle.Transient);
            //business logic service
            container.Register<IProductService, ProductService>(Lifestyle.Scoped);
            container.Register<ISaleService, SaleService>(Lifestyle.Scoped);
            container.Register<IUserLoginService, UserLoginService>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            //container.Verify();
            //SimpleInjectorServiceHostFactory.SetContainer(container);
            // 4. Store the container for use by the application  

            container.Verify();
            SimpleInjectorServiceHostFactory.SetContainer(container);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}