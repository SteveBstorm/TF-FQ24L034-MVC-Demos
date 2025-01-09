using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal = DAL.Entities;
using bll = BLL.Models;

namespace BLL.Tools
{
    public static class Mappers
    {
        public static bll.User ToBll(this dal.User user)
        {
            return new bll.User
            {
                Id = user.Id,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Username = user.Username
            };
        }
    }
}
