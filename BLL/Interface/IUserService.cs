using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IUserService
    {
        void Register(string email, string username, string password);
        User Login(string email, string password);
        IEnumerable<User> GetAll();
        void SetUserAsAdmin(int id);
    }
}
