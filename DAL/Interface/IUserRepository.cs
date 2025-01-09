using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUserRepository
    {
        void Register(string email, string username, string password);
        User GetByEmail(string email);
        string GetPassword(string email);
        IEnumerable<User> GetAll();
        void SetUserAsAdmin(int id);
    }
}
