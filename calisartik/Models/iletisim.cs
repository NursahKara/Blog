using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace calisartik.Models
{
	public partial class iletisim
	{
		public int iletisimId { get; set; }
		
		[StringLength(100)]
		[Display(Name = "Adınız")]
		[Required(ErrorMessage = "Lütfen Adınızı giriniz!")]
		public string Ad { get; set; }

		[StringLength(100)]
		[Display(Name = "Soyadınız")]
		[Required(ErrorMessage = "Lütfen Soyadınız giriniz!")]
		public string Soyad { get; set; }

		[StringLength(70)]
		[Required(ErrorMessage = "Lütfen mail adresinizi giriniz!")]
		[Display(Name = "Eposta adresiniz")]
		[EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz!")]
		public string Eposta { get; set; }

		[StringLength(300)]
		[Required(ErrorMessage = "Lütfen mesajınızı giriniz!")]
		[Display(Name = "Mesajınızı yazınız")]
		public string Mesaj { get; set; }

		public DateTime OlusturmaTarihi { get; set; }
	}
}