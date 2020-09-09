using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calisartik.Models
{
	public class YorumEkModel
	{

		public List<icerik> icerikID { get; set; }
		public List<kullanici> kullaniciId { get; set; }
		public List<Yorum> yorumlar { get; set; }
		
		public YorumEkModel()
		{
			calisartikContext db = new calisartikContext();
			kullanici model1 = new kullanici();
			icerik model = new icerik();
			Yorum model3 = new Yorum();
			icerikID = db.icerikler.ToList();
			kullaniciId = db.kullanicilar.ToList();
		}
	}
}