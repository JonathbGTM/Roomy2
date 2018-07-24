using RoomyLeRetour.Data;
using RoomyLeRetour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomyLeRetour.Utils;

namespace RoomyLeRetour.Controllers
{
    public class UsersController : Controller
    {
        private RoomyDbContext db = new RoomyDbContext();

        // GET: Users
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Civilities = db.Civilities.ToList();
            //ViewBag.NbrPersonne = 4;
            return View();
        }

        // POST: Users
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                //ModelState.Remove("Password");
                //ModelState.Remove("ConfirmedPassword");
                user.Password = user.Password.HashMD5();

                db.Users.Add(user);
                db.SaveChanges();

                //Redirection
                TempData["Message"] = $"Utilisateur {user.LastName} enregistré";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Civilities = db.Civilities.ToList();
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}