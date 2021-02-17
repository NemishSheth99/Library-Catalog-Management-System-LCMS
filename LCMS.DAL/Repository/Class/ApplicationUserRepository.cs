using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Repository.Interface;
using LCMS.Models.ApplicationUser;
using AutoMapper;

namespace LCMS.DAL.Repository.Class
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly Database.LCMSDBEntities _dbContext;

        public ApplicationUserRepository()
        {
            _dbContext = new Database.LCMSDBEntities();
        }

        public ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin)
        {
            try
            {
                ApplicationUserDetail user = new ApplicationUserDetail();
                var obj = _dbContext.ApplicationUsers.Where(x => x.EmailAddress == applicationUserLogin.EmailAddress && x.Password == applicationUserLogin.Password && x.Status == "A" && x.IsDeleted == false).FirstOrDefault();
                if (obj != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.ApplicationUser, ApplicationUserDetail>());
                    var mapper = new Mapper(config);
                    user = mapper.Map<ApplicationUserDetail>(obj);
                    return user;
                }
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ApplicationUserDetail> GetApplicationUsers()
        {
            var list = _dbContext.ApplicationUserRoles.Where(x => x.UserRole.Role != "Librarian").Select(x=>x.ApplicationUser).ToList();
            //var list = _dbContext.ApplicationUsers.Where(x => x.IsDeleted == false).ToList();
            List<ApplicationUserDetail> lst = new List<ApplicationUserDetail>();

            if (list != null)
            {
                foreach (var items in list)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.ApplicationUser, ApplicationUserDetail>());
                    var mapper = new Mapper(config);
                    ApplicationUserDetail obj = mapper.Map<ApplicationUserDetail>(items);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public ApplicationUserDetail GetApplicationUserById(int id)
        {
            try
            {
                ApplicationUserDetail user = new ApplicationUserDetail();
                var obj = _dbContext.ApplicationUsers.Find(id);
                if (obj != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.ApplicationUser, ApplicationUserDetail>());
                    var mapper = new Mapper(config);
                    user = mapper.Map<ApplicationUserDetail>(obj);
                    return user;
                }
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Create(AddApplicationUserRequest applicationUserRequest)
        {
            try
            {
                if (applicationUserRequest != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<AddApplicationUserRequest, Database.ApplicationUser>());
                    var mapper = new Mapper(config);
                    Database.ApplicationUser obj = mapper.Map<Database.ApplicationUser>(applicationUserRequest);
                    obj.Status = "A";
                    obj.IsDeleted = false;
                    _dbContext.ApplicationUsers.Add(obj);
                    _dbContext.SaveChanges();
                    return "Success";
                }
                return "Fail";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(AddApplicationUserRequest applicationUserRequest)
        {
            try
            {
                var obj = _dbContext.ApplicationUsers.Find(applicationUserRequest.Id);
                if (obj != null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<AddApplicationUserRequest, Database.ApplicationUser>());
                    var mapper = new Mapper(config);
                    mapper.Map(applicationUserRequest, obj);
                    _dbContext.SaveChanges();
                    return "Success";
                }
                return "Fail";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //public string UpdateActiveStatus(int id, string status)
        //{
        //    try
        //    {
        //        var obj = _dbContext.ApplicationUsers.Find(id);
        //        if (obj != null)
        //        {
        //            obj.Status = status;
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

        //public string Delete(int id)
        //{
        //    try
        //    {
        //        var obj = _dbContext.ApplicationUsers.Find(id);
        //        if (obj != null)
        //        {
        //            obj.IsDeleted = true;
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
