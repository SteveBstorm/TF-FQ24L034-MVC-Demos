using ASPMVC_Demo01.Handlers.Validations;
using ASPMVC_Demo01.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPMVC_Demo01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            return View();
        }

        public IActionResult Demo01()
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            return View();
        }

        public IActionResult Demo02(int? id)
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            ViewData["text"] = $"Voici un exemple de texte provenant directement du controller : {nameof(HomeController)}";
            ViewBag.id = id;
            return View();
        }

        public IActionResult Demo04() {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            ViewData["text"] = "Je suis un message venant de l'action Demo04 et sauvé dans le ViewData.";
            TempData["text"] = "Je suis un message venant de l'action Demo04 et sauvé dans le TempData.";
            return RedirectToAction(nameof(Demo04ShowMessage));
        }
        public IActionResult Demo04ShowMessage()
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            TempData.Keep("text");
            return View();
        }

        public IActionResult Demo04TestMessage() {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            return View();
        }

        public IActionResult Demo05()
        {
            SaveCurrentUrl(HttpContext.Request.GetDisplayUrl());
            return View();
        }
        [HttpGet]
        public IActionResult Demo06()
        {
            return View();
        }
        [HttpPost]
        /*public IActionResult Demo06(IFormCollection form)
        {
            throw new NotImplementedException();
        }*/
        /*public IActionResult Demo06(string subject, string firstname, string lastname, DateOnly date, TimeOnly time)
        {
            throw new NotImplementedException();
        }*/
        public IActionResult Demo06(Demo06Form form) {
            /*if(form.Time < new TimeOnly(8,0) || form.Time > new TimeOnly(19, 30))
            {
                ModelState.AddModelError(nameof(form.Time), $"Attention : L'heure {form.Time.ToShortTimeString()} n'est pas compris entre 8:00 et 19:30.");
            }*/
            /*ValidationsExtension.ValidateTime(ModelState, form.Time, nameof(form.Time));*/
            ModelState
                .ValidateTime(form.Time,nameof(form.Time), new TimeOnly(8,0), new TimeOnly(19,30))
                .ValidateDate(form.Date, nameof(form.Date));
            if (ModelState.IsValid)
            {
                //Envoyer donnée dans la DB
                return RedirectToAction(nameof(Index));
            }
            else
            {

                return View();
            }
        }
        
        public IActionResult Demo07()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Demo07(Demo07Form form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        private void SaveCurrentUrl(string url)
        {
            if (TempData.ContainsKey("URLs"))
            {
                string[] urls = ((string[])TempData["URLs"]);
                List<string> urls_list = new List<string>(urls);
                urls_list.Add(url);
                TempData["URLs"] = urls_list;
            }
            else
            {
                TempData["URLs"] = new List<string>([url]);
            }
            TempData.Keep("URLs");
        }
    }
}
