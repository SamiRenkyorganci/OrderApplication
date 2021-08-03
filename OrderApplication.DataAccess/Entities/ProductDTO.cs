using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApplication.DataAccess.Entities
{
	public class ProductDTO
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Display(Name = "Key")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Resim")]
		public string ImageUrl { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Ürün Adı")]
		public string Name { get; set; }
	}
}
