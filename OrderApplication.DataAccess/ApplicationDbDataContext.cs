using Microsoft.EntityFrameworkCore;
using OrderApplication.DataAccess.Entities;
using OrderApplication.DataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.DataAccess
{
	public class ApplicationDbDataContext : DbContext
	{
		public ApplicationDbDataContext(DbContextOptions dbContext) : base(dbContext)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

		}

		#region Tables

		DbSet<ProductDTO> Products { get; set; }
		DbSet<AddressDTO> Addresses { get; set; }
		DbSet<OrderDTO> Orders { get; set; }
		DbSet<CustomerDTO> Customers { get; set; }


		#endregion

		#region Seeder
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AddressDTO>().HasData( //Veritabnı oluşturulurken addres tablosuna data ekleniyor.
				  DataSeeder.AddressSeeder()
			  );
			modelBuilder.Entity<ProductDTO>().HasData( //Veritabnı oluşturulurken product tablosuna data ekleniyor.
				   DataSeeder.ProductSeeder()
			   );
		}
		#endregion
	}
}
