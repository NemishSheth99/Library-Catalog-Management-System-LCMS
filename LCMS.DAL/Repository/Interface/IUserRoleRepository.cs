using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models;

namespace LCMS.DAL.Repository.Interface
{
    public interface IUserRoleRepository
    {
        int GetRoleId(string role);
    }
}
