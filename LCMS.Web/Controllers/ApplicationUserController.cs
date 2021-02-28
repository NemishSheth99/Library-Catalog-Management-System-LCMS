using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCMS.ServiceProxy.ApplicationUser;
using LCMS.ServiceProxy.ApplicationUserRole;
using LCMS.ServiceProxy.UserRole;
using LCMS.Models.ApplicationUser;
using LCMS.Models.ApplicationUserRole;
using LCMS.Models.UserRole;
using LCMS.Web.Models;
using AutoMapper;

namespace LCMS.Web.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserServiceProxy _applicationUserServiceProxy;
        private readonly IUserRoleServiceProxy _userRoleServiceProxy;
        private readonly IApplicationUserRoleServiceProxy _applicationUserRoleServiceProxy;

        public ApplicationUserController(IApplicationUserServiceProxy applicationUserServiceProxy,
            IUserRoleServiceProxy userRoleServiceProxy,
            IApplicationUserRoleServiceProxy applicationUserRoleServiceProxy)
        {
            _applicationUserServiceProxy = applicationUserServiceProxy;
            _userRoleServiceProxy = userRoleServiceProxy;
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
                    //// TO DO : mapping login vie model to application user login
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginVM, ApplicationUserLogin>());
                    var mapper = new Mapper(config);
                    ApplicationUserLogin user = mapper.Map<ApplicationUserLogin>(loginVM);

                    //// TO DO : call api for login
                    ApplicationUserDetail applicationUserDetail = _applicationUserServiceProxy.Login(user);
                    if (applicationUserDetail != null)
                    {
                        //// TO DO : Get User Role
                        ApplicationUserRoleDetail applicationUserRoleDetail = _applicationUserRoleServiceProxy.GetRoleDetail(applicationUserDetail.Id);
                        if (applicationUserRoleDetail != null)
                        {
                            Session["auid"] = applicationUserDetail.Id;
                            Session["auname"] = applicationUserDetail.Name;
                            string role = applicationUserRoleDetail.UserRole.Role;
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

        public ActionResult LibrarianDashboard()
        {
            return View();
        }

        public ActionResult UserIndex()
        {
            List<ApplicationUserDetail> userList = _applicationUserServiceProxy.GetApplicationUsers();
            return View(userList);
        }

        public ActionResult Create()
        {
            var roleList = new SelectList(_userRoleServiceProxy.GetUserRoleDetails(), "Id", "Role");
            ViewData["roleList"] = roleList;
            return View(new ApplicationUserCreateVM());
        }

        public ActionResult CreateUser(ApplicationUserCreateVM applicationUserVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserCreateVM, AddApplicationUserRequest>());
                    var mapper = new Mapper(config);
                    AddApplicationUserRequest user = mapper.Map<AddApplicationUserRequest>(applicationUserVM);
                    string result;
                    int userId, roleId;
                    if (applicationUserVM.Id == 0)
                    {
                        userId = _applicationUserServiceProxy.Create(user);
                        if (userId > 0)
                        {
                            roleId = applicationUserVM.RoleId;
                            AddApplicationUserRoleRequest addApplicationUserRoleRequest = new AddApplicationUserRoleRequest();
                            addApplicationUserRoleRequest.RoleId = roleId;
                            addApplicationUserRoleRequest.ApplicationUserId = userId;
                            result = _applicationUserRoleServiceProxy.Create(addApplicationUserRoleRequest);
                            if (result != null && result == "Success")
                            {
                                return RedirectToAction("UserIndex");
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

        public ActionResult Edit(int id)
        {
            var roleList = new SelectList(_userRoleServiceProxy.GetUserRoleDetails(), "Id", "Role");
            ViewData["roleList"] = roleList;
            ApplicationUserEditVM applicationUserVM = new ApplicationUserEditVM();
            ApplicationUserDetail applicationUserDetail = _applicationUserServiceProxy.GetApplicationUserById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDetail, ApplicationUserEditVM>());
            var mapper = new Mapper(config);
            applicationUserVM = mapper.Map<ApplicationUserEditVM>(applicationUserDetail);
            return View("Edit", applicationUserVM);
        }

        public ActionResult EditUser(ApplicationUserEditVM applicationUserVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserEditVM, UpdateApplicationUserRequest>());
                    var mapper = new Mapper(config);
                    UpdateApplicationUserRequest user = mapper.Map<UpdateApplicationUserRequest>(applicationUserVM);
                    string result;
                    if (applicationUserVM.Id != 0)
                    {
                        result = _applicationUserServiceProxy.Update(user);
                        if (result != null && result == "Success")
                        {
                            return RedirectToAction("UserIndex");
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

        public ActionResult Delete(int id)
        {
            string result;
            result = _applicationUserServiceProxy.Delete(id);
            //if (result == "Success")
            return RedirectToAction("UserIndex");
        }

    }
}