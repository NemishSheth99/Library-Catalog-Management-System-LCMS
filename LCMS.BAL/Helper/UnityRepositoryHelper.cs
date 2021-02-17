using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using LCMS.DAL.Repository.Class;
using Unity;
using Unity.Extension;

namespace LCMS.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IApplicationUserRepository, ApplicationUserRepository>();
            Container.RegisterType<IApplicationUserRoleRepository, ApplicationUserRoleRepository>();
            Container.RegisterType<IAuthorRepository, AuthorRepository>();
            Container.RegisterType<IBookCatalogRepository, BookCatalogRepository>();
            Container.RegisterType<IBookPlaceRepository, BookPlaceRepository>();
            Container.RegisterType<ITransactionHistoryRepository, TransactionHistoryRepository>();
            Container.RegisterType<IUserRoleRepository, UserRoleRepository>();
        }
    }
}
