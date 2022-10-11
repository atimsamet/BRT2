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
    public class CategoryController : Controller
    {
        CategoryService service;
        // GET: Category
        public ActionResult Index()
        {
            service = new CategoryService();
            return View(service.GetAllCategories());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            service = new CategoryService();
            service.Create(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        //wwww.test.com/Category/Edit/4
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            service = new CategoryService();
            service.Update(id, category);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id, Category category)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                var silinecekEleman = db.Categories.Find(id);
                service = new CategoryService();
                service.Delete(id, silinecekEleman);
                return RedirectToAction("Index");
            }
        }
    }
}