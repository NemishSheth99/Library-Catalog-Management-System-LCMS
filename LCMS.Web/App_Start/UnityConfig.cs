using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using LCMS.ServiceProxy.ApplicationUser;
using LCMS.ServiceProxy.ApplicationUserRole;
using LCMS.ServiceProxy.Author;
using LCMS.ServiceProxy.BookCatalog;
using LCMS.ServiceProxy.BookPlace;
using LCMS.ServiceProxy.TransactionHistory;
using LCMS.ServiceProxy.UserRole;

namespace LCMS.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IApplicationUserServiceProxy,ApplicationUserServiceProxy>();
            container.RegisterType<IApplicationUserRoleServiceProxy, ApplicationUserRoleServiceProxy>();
            container.RegisterType<IAuthorServiceProxy, AuthorServiceProxy>();
            container.RegisterType<IBookCatalogServiceProxy, BookCatalogServiceProxy>();
            container.RegisterType<IBookPlaceServiceProxy, BookPlaceServiceProxy>();
            container.RegisterType<ITransactionHistoryServiceProxy, TransactionHistoryServiceProxy>();
            container.RegisterType<IUserRoleServiceProxy, UserRoleServiceProxy>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}