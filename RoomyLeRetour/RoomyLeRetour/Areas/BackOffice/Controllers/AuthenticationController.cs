using RoomyLeRetour.Areas.BackOffice.Models;
using RoomyLeRetour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomyLeRetour.Utils;
using RoomyLeRetour.Filters;
using RoomyLeRetour.Controllers;

namespace RoomyLeRetour.Areas.BackOffice.Controllers
{
    public class AuthenticationController : BaseController
    {
        private RoomyDbContext db = new RoomyDbContext();


        // GET: BackOffice/Authentication/Login
        public ActionResult Login()
        {
            return View();
        }


        // POST: BackOffice/Authentication/Login
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(AuthenticationLoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = model.Password.HashMD5();
                var user = db.Users.SingleOrDefault(x => x.Mail == model.Login && x.Password == passwordHash);
                if (user == null)
                {
                    // Méthode 1 
                    // ModelState.AddModelError("", "Utilisateur ou mot de passe incorrect");

                    // Méthode 2
                    ViewBag.ErrorMessage = "Utilisateur ou mot de passe incorrect";
                    return View(model);
                }

                else
                {
                    Session.Add("USER_BO", user);
                    return RedirectToAction("Index", "Dashboard", new { area = "BackOffice" });
                }
            }

            return View(model);

        }

        // GET:BackOffice/Authentication/Logout

        [AuthenticationFilter]

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}