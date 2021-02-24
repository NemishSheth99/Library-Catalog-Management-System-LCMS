﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.DAL.Database;
using LCMS.Models.ApplicationUser;

namespace LCMS.BAL.Interface
{
    public interface IApplicationUserManager
    {
        ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin);
        List<ApplicationUserDetail> GetApplicationUsers();
        ApplicationUserDetail GetApplicationUserById(int id);
        ApplicationUserDetail GetApplicationUserByEmailAddress(string emailAddress);
        int Create(AddApplicationUserRequest applicationUserRequest);
        string Update(UpdateApplicationUserRequest applicationUserRequest);
        string UpdateActiveStatus(int id, string status);
        string Delete(int id);
        string ChangePassword(int id, string password);
    }
}
