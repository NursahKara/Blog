using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using calisartik.Models;


namespace blog.Controllers
{
	public class HomeController : Controller
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string sayfa_id = Request.QueryString["sayfa"];
			if (Session[sayfa_id] == null)
			{
				Console.WriteLine("Sayfayı ilk kez okuyorsunuz.");
				Session[sayfa_id] = "okundu";
			}
			else
			{
				Console.WriteLine("Daha önce bu sayfayı okumuşsunuz.");
			}
		}
		[HttpGet]
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return Redirect(Request.UrlReferrer.PathAndQuery);
		}

		[HttpPost]
		public ActionResult YorumYaz(string yorum, int? icerikId)
		{
			if (!User.Identity.IsAuthenticated)
			{
				return Json(new { success = false, res = "Giriş yapmadan yorum yapamazsınız." });

			}
			if (yorum == "" || !icerikId.HasValue)
				return Json(new { success = false, res = "Yorumu boş bıraktınız." });

			calisartikContext db = new calisartikContext();
			try
			{
				db.yorumlar.Add(new Yorum()
				{
					icerikId = icerikId.Value,
					YapilanYorum = yorum,
					kullanici = User.Identity.Name,
					OlusturmaTarihi = DateTime.Now
				});
				db.SaveChanges();
				return Redirect(Request.UrlReferrer.PathAndQuery);
			}
			catch
			{
				return Json(new { success = false });
			}
		}

		[HttpPost]
		public ActionResult Login(kullanici model)
		{
			if (model.email == null || model.sifre == null)
			{
				return Json(new { success = false, res = "Boşluk Bırakmayınız." });
			}
			calisartikContext db = new calisartikContext();
			try
			{
				var query = db.kullanicilar.SingleOrDefault(w => w.email == model.email && w.sifre == model.sifre);
				if (query != null)
				{
					FormsAuthentication.SetAuthCookie(model.email, false);
					return Redirect(Request.UrlReferrer.PathAndQuery);
				}

				return Json(new { success = false, res = "Email ya da şifre yanlış." });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, res = ex.ToString() });
			}
		}
		[HttpPost]
		public ActionResult Register(kullanici model)
		{
			if (model.email == null || model.adSoyad == null || model.sifre == null)
			{
				return Json(new { success = false, res = "Boşluk Bırakmayınız." });
			}
			calisartikContext db = new calisartikContext();
			try
			{
				var query = db.kullanicilar.SingleOrDefault(w => w.email == model.email);
				if (query != null)
				{
					return Json(new { success = false, res = "Bu email kullanılmış!" });
				}
				db.kullanicilar.Add(model);
				db.SaveChanges();
				FormsAuthentication.SetAuthCookie(model.email, false);
				return Redirect(Request.UrlReferrer.PathAndQuery);
			}
			catch (Exception ex)
			{
				return Json(new { success = false, res = ex.ToString() });
			}
		}
		public ActionResult index()
		{
			IndexViewModel model = new IndexViewModel();
			slider model2 = new slider();
			calisartikContext db = new calisartikContext();

			model.SonEklenenler = db.icerikler.OrderByDescending(w => w.OlusturmaTarihi).Take(5).ToList();
			model.icerikID = db.icerikler.OrderByDescending(w => w.OlusturmaTarihi).Take(5).ToList();

			return View(model);
		}

		public ActionResult hakkimda()
		{
			return View();
		}
		public ActionResult iletisim()
		{
			return View();
		}
		
		public ActionResult Makaleler()
		{
			calisartikContext db = new calisartikContext();
			var query = db.icerikler.ToList();
			return View(query);
		}
		public ActionResult Kodlama(int? id)
		{
			if (!id.HasValue)
			{
				return RedirectToAction("index", "Home");
			}
			try
			{
				calisartikContext db = new calisartikContext();
				var query = db.icerikler.SingleOrDefault(w => w.icerikID == id);
				if (query == null)
				{
					return RedirectToAction("index", "Home");

				}
				MakaleViewModel model = new MakaleViewModel()
				{
					icerikID = query.icerikID,
					Yazar = query.Yazar,
					Baslik = query.Baslik,
					BaslikFoto = query.BaslikFoto,
					Metin = query.Metin,
					OlusturmaTarihi = query.OlusturmaTarihi,
				};
				model.yorumlar = db.yorumlar.Where(w => w.icerikId == query.icerikID).OrderByDescending(w => w.OlusturmaTarihi).ToList();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("index", "Home");
			}

		}
		
	
		public ActionResult Makale(int? id)
		{
			if (!id.HasValue)
			{
				return RedirectToAction("index", "Home");
			}
			try
			{
				calisartikContext db = new calisartikContext();
				var query = db.icerikler.SingleOrDefault(w => w.icerikID == id);
				if (query == null)
				{
					return RedirectToAction("index", "Home");
				}
				MakaleViewModel model = new MakaleViewModel()
				{
					icerikID = query.icerikID,
					Yazar = query.Yazar,
					Baslik = query.Baslik,
					BaslikFoto = query.BaslikFoto,
					Metin = query.Metin,
					OlusturmaTarihi = query.OlusturmaTarihi,

				};
				model.yorumlar = db.yorumlar.Where(w => w.icerikId == query.icerikID).OrderByDescending(w => w.OlusturmaTarihi).ToList();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("index", "Home");
			}
		}
		public ActionResult oop()
		{
			return View();
		}
		public ActionResult pdp()
		{
			return View();
		}
		public ActionResult Cs()
		{
			return View();
		}
		public ActionResult yazilim_gelistirme()
		{
			return View();
		}
		public ActionResult yazilimmuh()
		{
			return View();
		}
		
		public ActionResult mvc()
		{
			return View();
		}

		public ActionResult c()
		{
			calisartikContext db = new calisartikContext();
			var query = db.icerikler.Where(w => w.icerikturu == 1).ToList();
			return View(query);
		}
		public ActionResult cplus()
		{
			calisartikContext db = new calisartikContext();
			var query = db.icerikler.Where(w=>w.icerikturu==2).ToList();
			return View(query);
		}
		public ActionResult csharp()
		{
			calisartikContext db = new calisartikContext();
			var query = db.icerikler.Where(w => w.icerikturu == 3).ToList();
			return View(query);
		}
		public ActionResult java()
		{
			calisartikContext db = new calisartikContext();
			var query = db.icerikler.Where(w => w.icerikturu == 4).ToList();
			return View(query);
		}
		public ActionResult html()
		{
			calisartikContext db = new calisartikContext();
			var query = db.icerikler.Where(w => w.icerikturu == 5).ToList();
			return View(query);
		}
		public ActionResult veritabanlari()
		{
			calisartikContext db = new calisartikContext();
			var query = db.icerikler.Where(w => w.icerikturu == 6).ToList();
			return View(query);
		}
		public ActionResult mobil()
		{
			calisartikContext db = new calisartikContext();
			var query = db.icerikler.Where(w => w.icerikturu == 7).ToList();
			return View(query);
		}

	}
}