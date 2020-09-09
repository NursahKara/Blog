using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using calisartik.Models;

namespace calisartik.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]

		[ValidateInput(false)]
		public ActionResult CreateContent(string baslik, string metin, HttpPostedFileBase baslikfoto,int icerikturu, string yazar)
		{
			icerik model = new icerik()
			{
				Baslik = baslik,
				Metin = metin,
				BaslikFoto = fileUpload(baslikfoto),
				icerikturu = icerikturu,
				Yazar=yazar,

			};
			try
			{
				calisartikContext db = new calisartikContext();
				model.OlusturmaTarihi = DateTime.UtcNow;
				db.icerikler.Add(model);
				db.SaveChanges();
				return Redirect(Request.UrlReferrer.PathAndQuery);
			}
			catch (Exception ex)
			{
				return Json(new { success = false, res = ex.ToString() });
			}
		}
		
		public string fileUpload(HttpPostedFileBase file)
		{
			if (file!=null)
			{
				string pic = System.IO.Path.GetFileName(file.FileName);
				string path = System.IO.Path.Combine(
				Server.MapPath("~/images/"), pic);
				file.SaveAs(path);
				path = path.Replace("\\","/");
				path = "/images" + path.Split(new string[] { "images" }, StringSplitOptions.None)[1];
				return path;
				
			}
			return "";
		}
		public ActionResult sliderUpload(HttpPostedFileBase sliderfoto)
		{
			slider model = new slider()
			{
				sliderFoto = fileUpload(sliderfoto),

			};
			try
			{
				calisartikContext db = new calisartikContext();
				model.OlusturmaTarihi = DateTime.UtcNow;
				db.sliderlar.Add(model);
				db.SaveChanges();
				return Redirect(Request.UrlReferrer.PathAndQuery);
			}
			catch (Exception ex)
			{
				return Json(new { success = false, res = ex.ToString() });
			}
		}

		[ValidateInput(false)]
		public ActionResult icerikler()
		{
			return View();
		}
		public ActionResult Sliderlar()
		{
			return View();
		}
		public ActionResult Yorumlar()
		{
			return View();
			
		}
		public ActionResult iletisimformu()
		{
			var model = new List<iletisim> ();
			calisartikContext db = new calisartikContext();
			model = db.iletisimler.ToList();
			return View(model);
		}
		public ActionResult Kategoriler()
		{
			return View();
		}
		public ActionResult ProfilAyarlari()
		{
			return View();
		}
		public ActionResult Ayarlar()
		{
			return View();
		}
		public ActionResult iletisimMesajlari(string ad, string soyad, string eposta, string mesaj)
		{
			iletisim model = new iletisim()
			{
				Ad = ad,
				Soyad = soyad,
				Eposta = eposta,
				Mesaj = mesaj,
				OlusturmaTarihi = DateTime.Now
		};

			try
			{
				calisartikContext db = new calisartikContext();
				db.iletisimler.Add(model);
				db.SaveChanges();
				return Redirect(Request.UrlReferrer.PathAndQuery);
			}
			catch (Exception ex)
			{
				return Json(new { success = false, res = ex.ToString() });
			}
		}
	
	}
	
	
}