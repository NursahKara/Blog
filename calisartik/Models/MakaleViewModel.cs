using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calisartik.Models
{
	public class MakaleViewModel
	{
		public int icerikID { get; set; }
		public string Yazar { get; set; }
		public string Baslik { get; set; }
		public string Metin { get; set; }
		public string BaslikFoto { get; set; }
		public int icerikturu { get; set; }
		public List<Yorum> yorumlar { get; set; }
		public DateTime OlusturmaTarihi { get; set; }

	}
	
}