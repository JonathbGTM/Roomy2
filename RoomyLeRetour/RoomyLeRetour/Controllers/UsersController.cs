using RoomyLeRetour.Data;
using RoomyLeRetour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            }
            return View();
        }
    }
}