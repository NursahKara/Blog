using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calisartik.Models
{
	public class kullanici
	{	
		public int kullaniciId { get; set; }
		[Required]
		public string adSoyad { get; set; }
		[Required]
		public string email { get; set; }
		[Required]
		public string sifre { get; set; }
	}

}