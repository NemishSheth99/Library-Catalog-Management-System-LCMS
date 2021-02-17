using LCMS.BAL.Helper;
using LCMS.BAL.Interface;
using LCMS.BAL.Class;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace LCMS.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IApplicationUserManager, ApplicationUserManager>();
            container.RegisterType<IApplicationUserRoleManager, ApplicationUserRoleManager>();
            container.RegisterType<IAuthorManager, AuthorManager>();
            container.RegisterType<IBookCatalogManager, BookCatalogManager>();
            container.RegisterType<IBookPlaceManager, BookPlaceManager>();
            container.RegisterType<ITransactionHistoryManager, TransactionHistoryManager>();
            container.RegisterType<IUserRoleManager, UserRoleManager>();
            container.AddNewExtension<UnityRepositoryHelper>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}