using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCMS.ServiceProxy.ApplicationUser;
using LCMS.ServiceProxy.ApplicationUserRole;
using LCMS.Models.ApplicationUser;
using LCMS.Models.ApplicationUserRole;
using LCMS.Web.Models;
using AutoMapper;

namespace LCMS.Web.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserServiceProxy _applicationUserServiceProxy;
        private readonly IApplicationUserRoleServiceProxy _applicationUserRoleServiceProxy;

        public ApplicationUserController(IApplicationUserServiceProxy applicationUserServiceProxy,IApplicationUserRoleServiceProxy applicationUserRoleServiceProxy)
        {
            _applicationUserServiceProxy = applicationUserServiceProxy;
            _applicationUserRoleServiceProxy = applicationUserRoleServiceProxy;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(LoginVM loginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginVM, ApplicationUserLogin>());
                    var mapper = new Mapper(config);
                    ApplicationUserLogin user = mapper.Map<ApplicationUserLogin>(loginVM);
                    ApplicationUserDetail applicationUserDetail = _applicationUserServiceProxy.Login(user);
                    if(applicationUserDetail!=null)
                    {
                        ApplicationUserRoleDetail applicationUserRoleDetail = _applicationUserRoleServiceProxy.GetRoleDetail(applicationUserDetail.Id);
                        if(applicationUserRoleDetail!=null)
                        {
                            Session["auid"] = applicationUserDetail.Id;
                            Session["auname"] = applicationUserDetail.Name;
                            string role= applicationUserRoleDetail.UserRole.Role;
                            if (role != null)
                            {
                                Session["aurole"] = role;
                                if (role == "Librarian")
                                    return RedirectToAction("LibrarianDashboard");
                                else
                                    return RedirectToAction("UserDashboard");
                            }
                        }
                    }
                }
                return View("Login");
            }
            catch (Exception ex)
            {
                //log.Error("Exception : " + ex);
                return View("Login");
            }
        }

        public ActionResult UserIndex()
        {
            List<ApplicationUserDetail> userList = _applicationUserServiceProxy.GetApplicationUsers();
            return View(userList);
        }

        public ActionResult Create()
        {
            return View(new ApplicationUserVM());
        }

        public ActionResult Edit(int id)
        {
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            ApplicationUserDetail applicationUserDetail = _applicationUserServiceProxy.GetApplicationUserById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDetail, ApplicationUserVM>());
            var mapper = new Mapper(config);
            applicationUserVM = mapper.Map<ApplicationUserVM>(applicationUserDetail);
            return View("Create",applicationUserVM);
        }

        public ActionResult CreateOrEdit(ApplicationUserVM applicationUserVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserVM, AddApplicationUserRequest>());
                    var mapper = new Mapper(config);
                    AddApplicationUserRequest user = mapper.Map<AddApplicationUserRequest>(applicationUserVM);
                    string result;
                    if (applicationUserVM.Id == 0)
                        result = _applicationUserServiceProxy.Create(user);
                    else
                        result = _applicationUserServiceProxy.Update(user);
                    if (result!=null && result=="Success")
                    {
                        return RedirectToAction("UserIndex");
                    }
                }
                return View("Login");
            }
            catch (Exception ex)
            {
                //log.Error("Exception : " + ex);
                return View("Login");
            }
        }

    }
}