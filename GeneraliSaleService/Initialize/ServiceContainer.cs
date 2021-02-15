using BusinessLogic.Services.EntityServices;
using BusinessLogic.Services.LogicServices;
using Core.Interfaces.Services;
using Core.Interfaces.UnitOfWork;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.UnitOfWork;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GeneraliSaleService.Initialize
{
    public class ServiceContainer
    {
        public static readonly Container Container;

        static ServiceContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register WCF services.
            container.RegisterWcfServices(Assembly.GetExecutingAssembly());

            container.Register<ApplicationDbContext>(Lifestyle.Scoped);

            //metadata services
            //container.Register<ICustomerTableService, CustomerService>(Lifestyle.Transient);
            
            container.Register<IProductTableService, ProductTableService>(Lifestyle.Scoped);
            container.Register<ISaleDetailService, SaleDetailService>(Lifestyle.Scoped);
            container.Register<ISalesTableService, SalesTableService>(Lifestyle.Scoped);
            
            container.Register<IUserService, UserTableService>(Lifestyle.Scoped);
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
            Container = container;
        }
    }
}