using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calisartik.Models
{
	public class Yorum
	{
		public int YorumId { get; set; }
		public string kullanici { get; set; }
		public int icerikId { get; set; }
		public string YapilanYorum { get; set; }
		public DateTime OlusturmaTarihi { get; set; }
	}
}