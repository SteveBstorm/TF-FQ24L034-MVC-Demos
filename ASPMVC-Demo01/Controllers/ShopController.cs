using Demo = ASPMVC_Demo01.Models;
using Dal = DAL.Entities;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ASPMVC_Demo01.Tools;

namespace ASPMVC_Demo01.Controllers
{
    public class ShopController : Controller
    {

        private Demo.Product[] _products = [
            new Demo.Product(){Name = "Tickets de loterie", Price = 2.5M, Quantity=100 },
            new Demo.Product(){Name = "Montre", Price = 250M, Quantity = 10},
            new Demo.Product(){Name = "Vin", Price = 15M, Quantity = 75 },
            new Demo.Product(){Name = "Parfum", Price = 50M, Quantity = 25 },
            new Demo.Product(){Name = "Chaussettes", Price = 7.5M, Quantity = 0 }];
        [ViewData]
        public string Title { get; set; }
        public IActionResult Index()
        {
            Title = "Liste des produits";
            IEnumerable<Demo.ProductListItem> model = _products
                .Select(p => new Demo.ProductListItem() { Name = p.Name, Price = p.Price}) ;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            try
            {
                if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), "Indice ne peut être en dessous de 0");
                if (id >= _products.Length) throw new ArgumentOutOfRangeException(nameof(id), $"Indice ne peut être au dessus de {_products.Length - 1}");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            Demo.Product model = _products[id];
            Title = $"Vue détaillée de {model.Name}";
            return View(model);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Demo.ProductForm product)
        {
            if(!ModelState.IsValid) 
            { 
                return View(product);
            }

            ProductRepository repo = new ProductRepository();

            try
            {
                repo.Create(product.ToDal());
            }
            catch(Exception ex)
            {
                ViewData["error"] = ex.Message;
                return View(product);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
