using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCMS.Core;
using LCMS.ServiceProxy.ApplicationUser;
using LCMS.ServiceProxy.ApplicationUserRole;
using LCMS.ServiceProxy.BookCatalog;
using LCMS.ServiceProxy.BookPlace;
using LCMS.ServiceProxy.UserRole;
using LCMS.Models.ApplicationUser;
using LCMS.Models.ApplicationUserRole;
using LCMS.Models.UserRole;
using LCMS.Web.Models;
using LCMS.Web.Filters;
using AutoMapper;

namespace LCMS.Web.Controllers
{
    
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserServiceProxy _applicationUserServiceProxy;
        private readonly IUserRoleServiceProxy _userRoleServiceProxy;
        private readonly IApplicationUserRoleServiceProxy _applicationUserRoleServiceProxy;
        private readonly IBookCatalogServiceProxy _bookCatalogServiceProxy;
        private readonly IBookPlaceServiceProxy _bookPlaceServiceProxy;

        public ApplicationUserController(IApplicationUserServiceProxy applicationUserServiceProxy,
            IUserRoleServiceProxy userRoleServiceProxy,
            IApplicationUserRoleServiceProxy applicationUserRoleServiceProxy,
            IBookCatalogServiceProxy bookCatalogServiceProxy,
            IBookPlaceServiceProxy bookPlaceServiceProxy)
        {
            _applicationUserServiceProxy = applicationUserServiceProxy;
            _userRoleServiceProxy = userRoleServiceProxy;
            _applicationUserRoleServiceProxy = applicationUserRoleServiceProxy;
            _bookCatalogServiceProxy = bookCatalogServiceProxy;
            _bookPlaceServiceProxy = bookPlaceServiceProxy;
        }


        #region Common

        
        public ActionResult Login()
        {
            //throw new Exception("Hello World");
            return View();
        }

        //[Route("/ApplicationUser/Error")]
        //public ActionResult Error()
        //{
        //    return View("InternalServerError", "Shared");
        //}

        [HttpPost]
        public ActionResult LoginUser(LoginVM loginVM)
        {
            
            if (ModelState.IsValid)
            {
                //// TO DO : mapping login vie model to application user login
                var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginVM, ApplicationUserLogin>());
                var mapper = new Mapper(config);
                ApplicationUserLogin user = mapper.Map<ApplicationUserLogin>(loginVM);

                //// TO DO : call api for login
                ApplicationUserDetail applicationUserDetail = _applicationUserServiceProxy.Login(user);
                if (applicationUserDetail.EmailAddress != null)
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
                else
                {
                    TempData["invalidLogin"] = "Invalid Username or Password!!!";
                    return RedirectToAction("Login");
                }
            }
            TempData["invalidLogin"] = "Something went wrong!!!";
            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        public ActionResult Dashboard()
        {
            if (Session["aurole"].ToString() == "Librarian")
                return RedirectToAction("LibrarianDashboard");
            else
                return RedirectToAction("UserDashboard");
        }

        public ActionResult EditProfile(int id)
        {
            ApplicationUserEditProfileVM userVM = new ApplicationUserEditProfileVM();
            ApplicationUserDetail applicationUserDetail = _applicationUserServiceProxy.GetApplicationUserById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDetail, ApplicationUserEditProfileVM>());
            var mapper = new Mapper(config);
            userVM = mapper.Map<ApplicationUserEditProfileVM>(applicationUserDetail);
            return View("EditProfile", userVM);
        }

        public ActionResult EditUserProfile(ApplicationUserEditProfileVM applicationUserVM)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserEditProfileVM, EditProfileApplicationUser>());
                var mapper = new Mapper(config);
                EditProfileApplicationUser user = mapper.Map<EditProfileApplicationUser>(applicationUserVM);
                string result;
                if (applicationUserVM.Id != 0)
                {
                    result = _applicationUserServiceProxy.EditProfile(user);
                    if (result == "Success")
                    {
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("ErrorPage");
                    }
                }
            }
            return View("Login");
        }

        public ActionResult ChangePassword()
        {
            return View(new ApplicationUserChangePasswordVM());
        }

        public ActionResult ChangeUserPassword(ApplicationUserChangePasswordVM applicationUserVM)
        {
            if (ModelState.IsValid)
            {
                applicationUserVM.Id = Convert.ToInt32(Session["auid"]);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserChangePasswordVM, ChangePasswordApplicationUser>());
                var mapper = new Mapper(config);
                ChangePasswordApplicationUser user = mapper.Map<ChangePasswordApplicationUser>(applicationUserVM);
                string result = _applicationUserServiceProxy.ChangePassword(user);
                if (result == "Success")
                {
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    if (result == "Fail")
                        return RedirectToAction("ErrorPage");
                    else
                        return View("ChangePassword");
                }

            }
            return View("Login");
        }

        #endregion

        #region Librarian

        [CustomAuthorization("Librarian")]
        public ActionResult LibrarianDashboard()
        {
            ViewBag.UserCount = _applicationUserServiceProxy.ActiveUserCount();
            ViewBag.CatalogCount = _bookCatalogServiceProxy.ActiveCatalogCount();
            ViewBag.CheckoutCount = _bookPlaceServiceProxy.GetCheckOutCount();
            return View();
        }

        [CustomAuthorization("Librarian")]
        public ActionResult UserIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetApplicationUserIndex(int pageNo, string search)
        {
            ApplicationUserResponse userResponse = _applicationUserServiceProxy.GetApplicationUsers(pageNo, search);
            return Json(userResponse, JsonRequestBehavior.AllowGet);
        }

        [CustomAuthorization("Librarian")]
        public ActionResult Create()
        {
            var roleList = new SelectList(_userRoleServiceProxy.GetUserRoleDetails(), "Id", "Role");
            ViewData["roleList"] = roleList;
            return View(new ApplicationUserCreateVM());
        }

        public ActionResult CreateUser(ApplicationUserCreateVM applicationUserVM)
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
                    Result rs = _applicationUserServiceProxy.Create(user);
                    if (rs.Status == "Success")
                    {
                        userId = Convert.ToInt32(rs.Data);
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
                    else
                    {
                        TempData["ErrorMessage"] = rs.Message;
                    }
                }
            }
            return RedirectToAction("Create");
        }

        [CustomAuthorization("Librarian")]
        public ActionResult Edit(int id)
        {
            ApplicationUserEditVM applicationUserVM = new ApplicationUserEditVM();
            ApplicationUserDetail applicationUserDetail = _applicationUserServiceProxy.GetApplicationUserById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDetail, ApplicationUserEditVM>());
            var mapper = new Mapper(config);
            applicationUserVM = mapper.Map<ApplicationUserEditVM>(applicationUserDetail);

            ApplicationUserRoleDetail roleDetail = _applicationUserRoleServiceProxy.GetRoleDetail(id);
            var roleList = new SelectList(_userRoleServiceProxy.GetUserRoleDetails(), "Id", "Role");
            ViewData["roleList"] = roleList;
            ViewBag.RoleId = roleDetail.UserRole.Id;
            return View("Edit", applicationUserVM);
        }

        public ActionResult EditUser(ApplicationUserEditVM applicationUserVM)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserEditVM, UpdateApplicationUserRequest>());
                var mapper = new Mapper(config);
                UpdateApplicationUserRequest applicationUserRequest = mapper.Map<UpdateApplicationUserRequest>(applicationUserVM);
                string result;
                if (applicationUserVM.Id != 0)
                {

                    Result rs = _applicationUserServiceProxy.Update(applicationUserRequest);
                    if (rs.Status == "Success")
                    {
                        int userId = applicationUserVM.Id;
                        if (userId > 0)
                        {
                            int roleId = applicationUserVM.RoleId;
                            AddApplicationUserRoleRequest addApplicationUserRoleRequest = new AddApplicationUserRoleRequest();
                            addApplicationUserRoleRequest.RoleId = roleId;
                            addApplicationUserRoleRequest.ApplicationUserId = userId;
                            //return RedirectToAction("UserIndex");
                            result = _applicationUserRoleServiceProxy.Update(addApplicationUserRoleRequest);
                            if (result != null && result == "Success")
                            {
                                return RedirectToAction("UserIndex");
                            }
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = rs.Message;
                    }
                }
            }
            return View("Login");
        }

        [CustomAuthorization("Librarian")]
        public ActionResult Delete(int id)
        {
            string result;
            result = _applicationUserServiceProxy.Delete(id);
            //if (result == "Success")
            return RedirectToAction("UserIndex");
        }

        [CustomAuthorization("Librarian")]
        public ActionResult ChangeActivity(int id)
        {
            string result = _applicationUserServiceProxy.UpdateActiveStatus(id);
            return RedirectToAction("UserIndex");
        }

        #endregion

        #region Other User

        [CustomAuthorization("Lawyer", "Specialist")]
        public ActionResult UserDashboard()
        {
            ViewBag.CatalogCount = _bookCatalogServiceProxy.ActiveCatalogCount();
            return View();
        }

        #endregion


    }
}