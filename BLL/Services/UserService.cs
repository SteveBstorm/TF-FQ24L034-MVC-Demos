using BLL.Interface;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using DAL.Interface;
using BLL.Tools;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Login(string email, string password)
        {
            User currentUser;
            string hashPwd;
            try
            {
                hashPwd = _userRepository.GetPassword(email);
            } 
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            if(BCrypt.Net.BCrypt.Verify(password, hashPwd)) 
            { 
                currentUser = _userRepository.GetByEmail(email).ToBll();
                return currentUser;
            }
            throw new ArgumentException("Mot de passe incorrect");
        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        

        public void Register(string email, string username, string password)
        {
            string hashPwd = BCrypt.Net.BCrypt.HashPassword(password);
            _userRepository.Register(email, username, hashPwd);
        }

        public void SetUserAsAdmin(int id)
        {
            throw new NotImplementedException();
        }
    }
}
