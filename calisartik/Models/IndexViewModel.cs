using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using calisartik.Models;

namespace calisartik.Models
{
	public class IndexViewModel
	{
		
	
		public List<icerik> SonMakaleler { get; set; }
		public List<icerik> SonEklenenler { get; set; }
		public List<icerik> SonIcerikler { get; set; }
		public List<slider> sliderfoto { get; set; }
		public List<icerik> baslik { get; set; }
		public List<icerik> icerikID { get; set; }
		public List<icerik> baslikfoto { get; set; }
		public List<icerik> icerikturu { get; set; }

		public IndexViewModel()
		{
			calisartikContext db = new calisartikContext();
			icerik model = new icerik();
			SonMakaleler = db.icerikler.OrderByDescending(w => w.OlusturmaTarihi).Take(5).ToList();
			SonEklenenler = db.icerikler.OrderByDescending(w => w.OlusturmaTarihi).Take(7).ToList();
			sliderfoto = db.sliderlar.ToList();
			baslik=db.icerikler.OrderBy(w => w.OlusturmaTarihi).Take(5).ToList();
			icerikID = db.icerikler.Where(w => w.icerikturu == 0).OrderByDescending(w=>w.OlusturmaTarihi).Take(5).ToList();
			baslikfoto = db.icerikler.OrderBy(w => w.OlusturmaTarihi).Take(5).ToList();
			icerikturu = db.icerikler.ToList();
		}

	}
}