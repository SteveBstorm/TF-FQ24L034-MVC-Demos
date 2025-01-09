using ASPMVC_Demo01.Models;
using ASPMVC_Demo01.Tools;
using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ASPMVC_Demo01.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly SessionManager _sessionManager;

        public AuthController(IUserService userService, SessionManager sessionManager)
        {
            _userService = userService;
            _sessionManager = sessionManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            if(!ModelState.IsValid)
            {
                return View(form);
            }
            _userService.Register(form.Email, form.Username, form.Password);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            try
            {
                User connectedUser = _userService.Login(form.Email, form.Password);
                _sessionManager.CurrentUser = connectedUser;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(form);
            }
            //return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            _sessionManager.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
