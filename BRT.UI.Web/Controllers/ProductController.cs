using BRT.Business.Services;
using BRT.DataAccess;
using BRT.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRT.UI.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductService service;
        // GET: Product
        public ActionResult Index()
        {
            service = new ProductService();
            List<Product> allProducts = service.GetAllProducts();
            return View(allProducts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product entity)
        {
            service = new ProductService();
            service.Create(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)//ActionResult yerine ViewResultta kullanılabilir(Metot sadece View() donecegi zaman)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            service = new ProductService();
            product.Id = id;
            service.Update(id, product);
            return RedirectToAction("Index");
        }
        [HttpGet]
       
       public ActionResult Remove(int id,Product product)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                service = new ProductService();
                var silinecekEleman = db.Products.Find(id);             
                service.Delete(id, silinecekEleman);
                return RedirectToAction("Index");
            }
           
        }
    }
}