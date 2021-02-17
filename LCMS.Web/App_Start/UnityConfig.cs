using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using LCMS.ServiceProxy.ApplicationUser;
using LCMS.ServiceProxy.ApplicationUserRole;

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
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}