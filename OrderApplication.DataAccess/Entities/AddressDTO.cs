using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApplication.DataAccess.Entities
{
	public class AddressDTO
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Display(Name = "Key")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Şehir")]
		public string City { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Ülke")]
		public string Country { get; set; }
		[Display(Name = "Adres")]
		public string AddressLine { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Şehir Kodu")]
		public int CityCode { get; set; }
	}
}
