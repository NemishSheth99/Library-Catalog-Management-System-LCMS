﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models.ApplicationUser;

namespace LCMS.BAL.Interface
{
    public interface IApplicationUserManager
    {
        ApplicationUserDetail Login(ApplicationUserLogin applicationUserLogin);
        List<ApplicationUserDetail> GetApplicationUsers();
        ApplicationUserDetail GetApplicationUserById(int id);
        int Create(AddApplicationUserRequest applicationUserRequest);
        string Update(AddApplicationUserRequest applicationUserRequest);
        //string UpdateActiveStatus(int id, string status);
        //string Delete(int id);
    }
}
