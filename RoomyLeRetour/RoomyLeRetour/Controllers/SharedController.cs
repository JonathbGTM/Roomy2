using RoomyLeRetour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomyLeRetour.Controllers
{
    public class SharedController : BaseController
    {
        private RoomyDbContext db = new RoomyDbContext();

        // GET: Shared
        [ChildActionOnly]
        public ActionResult TopFive()
        {
            var rooms = db.Rooms.OrderByDescending(x => x.Price).Take(5);
            return View("_TopFive", rooms);
        }
    }
}