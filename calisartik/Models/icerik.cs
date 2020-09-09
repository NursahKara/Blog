using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace calisartik.Models
{
	public class icerik
	{
		public int icerikID { get; set; }
		public string Yazar { get; set; }
		[Required]
		public string Baslik { get; set; }
		public string Metin { get; set; }
		public string BaslikFoto { get; set; }
		public int icerikturu { get; set; }
		public DateTime OlusturmaTarihi { get; set; }
		
	}
}