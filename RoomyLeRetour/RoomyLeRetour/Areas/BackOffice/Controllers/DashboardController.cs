using RoomyLeRetour.Controllers;
using RoomyLeRetour.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomyLeRetour.Areas.BackOffice.Controllers
{
    [AuthenticationFilter]
    public class DashboardController : BaseController
    {
        // GET: BackOffice/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}