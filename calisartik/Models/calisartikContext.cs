using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace calisartik.Models
{
	public class calisartikContext : DbContext
	{
		public DbSet<kullanici> kullanicilar { get; set; }
		public DbSet<iletisim> iletisimler { get; set; }
		public DbSet<icerik> icerikler { get; set; }
		public DbSet<slider> sliderlar { get; set; }
		public DbSet<Yorum> yorumlar { get; set; }
	}
}