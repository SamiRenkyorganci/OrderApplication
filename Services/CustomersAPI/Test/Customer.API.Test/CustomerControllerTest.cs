using Customer.API.Controllers;
using Customer.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderApplication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Customer.API.Test
{
	public class CustomerControllerTest
	{
		private Mock<ICustomerService> _customerService;
		private CustomerController _customerController;
		private List<CustomerDTO> customers;
		public CustomerControllerTest()
		{
			_customerService = new Mock<ICustomerService>();
			_customerController = new CustomerController(_customerService.Object);
			AddressDTO adress = new AddressDTO { AddressLine = "Test", City = "Konya", CityCode = 42, Country = "Türkiye", Id = Guid.NewGuid() };
			customers = new List<CustomerDTO>()
			{
				new CustomerDTO
				{
					CreateAt=DateTime.Now,
					Id=Guid.Parse("1a60a223-a369-421d-a60b-c25fa3b7399e"),
					Email="test@mail.com",
					Name="Test Customer",
					UpdateAt=DateTime.Now,
					AddressDTOId=adress.Id,
		},
		new CustomerDTO
				{
					CreateAt=DateTime.Now,
					Id=Guid.Parse("1a60a223-a369-421d-a60b-c25fa3b739a8"),
					Email="test2@mail.com",
					Name="Test Customer2",
					UpdateAt=DateTime.Now,
					AddressDTOId=adress.Id,
		}
	};

		}
		[Fact]
		public async Task Get_Return_OkResultWithCustomer()
		{
			_customerService.Setup(x => x.Get()).ReturnsAsync(customers);
			var result = await _customerController.Get();

			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnCustomer = Assert.IsType<List<CustomerDTO>>(okResult.Value);
			Assert.Equal<int>(2, returnCustomer.Count);


		}
		[Fact]
		public async Task Get_IdInValid_ReturnNotFound()
		{
			CustomerDTO customer = null;
			_customerService.Setup(x => x.Get(Guid.NewGuid())).ReturnsAsync(customer);
			var result = await _customerController.Get(Guid.NewGuid());

			Assert.IsType<NotFoundResult>(result);


		}
		[Theory]
		[InlineData("1a60a223-a369-421d-a60b-c25fa3b739a8")]
		[InlineData("1a60a223-a369-421d-a60b-c25fa3b7399e")]
		public async Task Get_IdValid_ReturnOkResult(Guid Id)
		{
			CustomerDTO customer = customers.First(x => x.Id == Id);
			_customerService.Setup(x => x.Get(Id)).ReturnsAsync(customer);
			var result = await _customerController.Get(Id);
			var okResult = Assert.IsType<OkObjectResult>(result);

			var returnCustomer = Assert.IsType<CustomerDTO>(okResult.Value);
			Assert.Equal(Id, returnCustomer.Id);
		}
		[Fact]
		public async Task Put_ActionExecutes_ReturnOkResult()
		{
			CustomerDTO customer = customers.First();
			_customerService.Setup(x => x.Update(customer));
			var result = await _customerController.Put(customer);

			_customerService.Verify(x => x.Update(customer), Times.Once);
			var Result = Assert.IsType<OkObjectResult>(result);

		}
		[Fact]
		public async Task Post_ActionExecutes_ReturnOkResult()
		{
			CustomerDTO customer = customers.First();
			_customerService.Setup(x => x.Create(customer));
			var result = await _customerController.Post(customer);

			_customerService.Verify(x => x.Create(customer), Times.Once);
			var Result = Assert.IsType<OkObjectResult>(result);

		}
		[Theory]
		[InlineData("1a60a223-a369-421d-a60b-c25fa3b739a8")]
		[InlineData("1a60a223-a369-421d-a60b-c25fa3b7399e")]
		public async Task Delete_IdValid_ReturnOkResult(Guid Id)
		{
			CustomerDTO customer = customers.First(x => x.Id == Id);
			_customerService.Setup(x => x.Delete(Id));
			var result = await _customerController.Delete(Id);
			var okResult = Assert.IsType<OkObjectResult>(result);
			_customerService.Verify(x => x.Delete(Id), Times.Once);

			var returnCustomer = Assert.IsType<bool>(okResult.Value);
		}
	}

}
