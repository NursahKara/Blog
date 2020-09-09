using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using calisartik.Models;

namespace calisartik.Controllers
{
    public class GridController : Controller
    {
		calisartikContext db = new calisartikContext();
        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult Makale()
		{
			var model = db.icerikler.ToList();
			return View(model);
		}
	}
}