using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using AutoMapper;
using LCMS.Models.ApplicationUserRole;
using LCMS.Models.UserRole;

namespace LCMS.DAL.Repository.Class
{
    public class ApplicationUserRoleRepository : IApplicationUserRoleRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public ApplicationUserRoleRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public ApplicationUserRoleDetail GetApplicationUserRoleDetail(int userId)
        {
            try
            {
                ApplicationUserRoleDetail roleDetail = new ApplicationUserRoleDetail();
                Database.ApplicationUserRole obj = _dbContext.ApplicationUserRoles.Where(x=>x.ApplicationUserId==userId).FirstOrDefault();
                if (obj != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.ApplicationUserRole, ApplicationUserRoleDetail>().ForMember(x=>x.UserRole,y=>y.Ignore()));                    
                    var mapper = new Mapper(config);
                    roleDetail = mapper.Map<ApplicationUserRoleDetail>(obj);
                    if (obj.UserRole != null)
                    {
                        var c = new MapperConfiguration(cfg => cfg.CreateMap<Database.UserRole, UserRoleDetail>());
                        var m = new Mapper(c);
                        roleDetail.UserRole = m.Map<UserRoleDetail>(obj.UserRole);
                    }                    
                    return roleDetail;
                }
                return roleDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public string Create(ApplicationUserRole applicationUserRole)
        //{
        //    try
        //    {
        //        if (applicationUserRole != null)
        //        {
        //            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserRole, Database.ApplicationUserRole>());
        //            var mapper = new Mapper(config);
        //            Database.ApplicationUserRole obj = mapper.Map<Database.ApplicationUserRole>(applicationUserRole);
        //            _dbContext.ApplicationUserRoles.Add(obj);
        //            _dbContext.SaveChanges();
        //            return "Success";
        //        }
        //        return "Fail";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

            //public string Update(ApplicationUserRole applicationUserRole)
            //{
            //    try
            //    {
            //        var role = _dbContext.ApplicationUserRoles.Find(applicationUserRole.Id);
            //        if (role != null)
            //        {
            //            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserRole, Database.ApplicationUserRole>());
            //            var mapper = new Mapper(config);
            //            mapper.Map(applicationUserRole, role);
            //            _dbContext.SaveChanges();
            //            return "Success";
            //        }
            //        return "Fail";
            //    }
            //    catch (Exception ex)
            //    {
            //        return ex.Message;
            //    }
            //}

            //public string Delete(int userId)
            //{
            //    try
            //    {
            //        var role = _dbContext.ApplicationUserRoles.Where(x=>x.ApplicationUserId==userId).FirstOrDefault();
            //        if (role != null)
            //        {
            //            _dbContext.ApplicationUserRoles.Remove(role);
            //            _dbContext.SaveChanges();
            //            return "Success";
            //        }
            //        return "Fail";
            //    }
            //    catch (Exception ex)
            //    {
            //        return ex.Message;
            //    }
            //}

        }
}
