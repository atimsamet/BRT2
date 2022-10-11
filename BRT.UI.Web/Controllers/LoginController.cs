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
    public class LoginController : Controller
    {
        LoginService service;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                foreach (var item in db.Logins.ToList())
                {
                    if (login.Password == item.Password && login.Username == item.Username)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                }
                ModelState.AddModelError("", "Hatalı Kullanıcı Adı veya Şifre");
                return View("Index");

            }
        }

        [HttpGet]
        public ActionResult ListUsers()
        {
            service = new LoginService();
            return View(service.GetAllUsers());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Login login)
        {
            service = new LoginService();
            service.Create(login);
            return RedirectToAction("ListUsers");
        }

        [HttpGet]
        //wwww.test.com/Category/Edit/4
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, Login login)
        {
            service = new LoginService();
            service.Update(id, login);
            return RedirectToAction("ListUsers");
        }

        public ActionResult Remove(int id, Login login)
        {
            using (BRTDbContext db = new BRTDbContext())
            {
                var silinecekEleman = db.Logins.Find(id);
                service = new LoginService();
                service.Delete(id, silinecekEleman);
                return RedirectToAction("ListUsers");
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Login login)
        {
            service = new LoginService();
            service.Create(login);
            return RedirectToAction("Index");
        }


    }
}
