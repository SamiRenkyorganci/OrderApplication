using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.DataAccess.Entities
{
	public class CustomerDTO
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Display(Name = "Key")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "İsim")]
		public string Name { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Email")]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
						   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
						   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
			ErrorMessage = "Email adresi geçersiz")]
		public string Email { get; set; }
		[Display(Name = "Adres")]

		public Guid AddressDTOId { get; set; }
		public AddressDTO AddressDTO { get; set; }
		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Oluşturulma Tarihi")]
		public DateTime CreateAt { get; set; }

		[Required(ErrorMessage = "{0} alanı boş geçilemez")]
		[Display(Name = "Güncelleme Tarihi")]
		public DateTime UpdateAt { get; set; }


	}
}
