using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApplication.DataAccess.Entities
{
	public class OrderDTO
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Display(Name = "Key")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Müşteri")]
		public Guid CustomerDTOId { get; set; }
		public CustomerDTO CustomerDTO { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Adet")]

		public int Quantity { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Fiyat")]

		public double Price { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Durum")]

		public string Status { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Ürün")]

		public Guid ProductDTOId { get; set; }
		public ProductDTO ProductDTO { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Adres")]
		public Guid AddressId { get; set; }
	
		public AddressDTO AddressDTO { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Oluşturulma Tarihi")]
		public DateTime CreateAt { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Güncelleme Tarihi")]
		public DateTime UpdateAt { get; set; }


	}
}
