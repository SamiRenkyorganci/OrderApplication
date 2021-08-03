using OrderApplication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApplication.DataAccess.Helpers
{
	public class DataSeeder
	{
        #region AddressSeeder

        public static AddressDTO[] AddressSeeder()
        {
            AddressDTO[] addresses =
            {
                new AddressDTO() {Id = Guid.NewGuid(), AddressLine="Fake Data AddressLine",City="Konya",Country="Türkiye",CityCode=42},
                new AddressDTO() {Id = Guid.NewGuid(), AddressLine="Fake Data AddressLine İstanbul",City="İstanbul",Country="Türkiye",CityCode=34}

            };
            return addresses;
        }


        #endregion 
        #region ProductSeeder

        public static ProductDTO[] ProductSeeder()
        {
            ProductDTO[] products =
            {
                new ProductDTO() {Id = Guid.NewGuid(), ImageUrl="/image/path",Name="Ürün 1"},
                new ProductDTO() {Id = Guid.NewGuid(), ImageUrl="/image/path",Name="Ürün 2"}

            };
            return products;
        }


#endregion



    }
}
