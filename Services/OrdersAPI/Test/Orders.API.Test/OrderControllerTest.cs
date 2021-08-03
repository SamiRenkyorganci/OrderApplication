using Order.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderApplication.DataAccess.Entities;
using Orders.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Order.Business.Abstract;

namespace Orders.API.Test
{
	public class OrderControllerTest
	{
		private Mock<IOrderService> _orderService;
		private OrderController _orderController;
		private List<OrderDTO> orders;
		public OrderControllerTest()
		{
			_orderService = new Mock<IOrderService>();
			_orderController = new OrderController(_orderService.Object);
			AddressDTO adress = new AddressDTO { AddressLine = "Test", City = "Konya", CityCode = 42, Country = "Türkiye", Id = Guid.NewGuid() };
			ProductDTO product = new ProductDTO { Id = Guid.NewGuid(), ImageUrl = "Image/path", Name = "Product1" };
			CustomerDTO customer = new CustomerDTO
			{
				CreateAt = DateTime.Now,
				Id = Guid.Parse("1a60a223-a369-421d-a60b-c25fa3b73922"),
				Email = "test@mail.com",
				Name = "Test Customer",
				UpdateAt = DateTime.Now,
				AddressDTOId = adress.Id,
			};
			orders = new List<OrderDTO>()
			{
				new OrderDTO
				{
					CreateAt=DateTime.Now,
					Id=Guid.Parse("1a60a223-a369-421d-a60b-c25fa3b7399e"),
					AddressId=adress.Id,
					CustomerDTOId=customer.Id,
					Price=22,
					ProductDTOId=product.Id,
					Quantity=1,
					Status="Durum",
					UpdateAt=DateTime.Now,


		},
		new OrderDTO
				{
					CreateAt=DateTime.Now,
					Id=Guid.Parse("1a60a223-a369-421d-a60b-c25fa3b739a8"),
					AddressId=adress.Id,
					CustomerDTOId=customer.Id,
					Price=22,
					ProductDTOId=product.Id,
					Quantity=1,
					Status="Durum",
					UpdateAt=DateTime.Now,
				}
	};

		}
		[Fact]
		public async Task Get_Return_OkResultWithOrder()
		{
			_orderService.Setup(x => x.Get()).ReturnsAsync(orders);
			var result = await _orderController.Get();

			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnOrder = Assert.IsType<List<OrderDTO>>(okResult.Value);
			Assert.Equal<int>(2, returnOrder.Count);


		}
		[Fact]
		public async Task Get_IdInValid_ReturnNotFound()
		{
			OrderDTO order = null;
			_orderService.Setup(x => x.Get(Guid.NewGuid())).ReturnsAsync(order);
			var result = await _orderController.Get(Guid.NewGuid());

			Assert.IsType<NotFoundResult>(result);


		}
		[Theory]
		[InlineData("1a60a223-a369-421d-a60b-c25fa3b739a8")]
		[InlineData("1a60a223-a369-421d-a60b-c25fa3b7399e")]
		public async Task Get_IdValid_ReturnOkResult(Guid Id)
		{
			OrderDTO order = orders.First(x => x.Id == Id);
			_orderService.Setup(x => x.Get(Id)).ReturnsAsync(order);
			var result = await _orderController.Get(Id);
			var okResult = Assert.IsType<OkObjectResult>(result);

			var returnorder = Assert.IsType<OrderDTO>(okResult.Value);
			Assert.Equal(Id, returnorder.Id);
		}
		[Fact]
		public async Task Put_ActionExecutes_ReturnOkResult()
		{
			OrderDTO order = orders.First();
			_orderService.Setup(x => x.Update(order));
			var result = await _orderController.Put(order);

			_orderService.Verify(x => x.Update(order), Times.Once);
			var Result = Assert.IsType<OkObjectResult>(result);

		}
		[Theory]
		[InlineData("1a60a223-a369-421d-a60b-c25fa3b739a8","Durum2")]
		public async Task ChangeStatus_ActionExecutes_ReturnOkResult(Guid Id,string status)
		{
			OrderDTO order = orders.First(a=>a.Id==Id);
			_orderService.Setup(x => x.ChangeStatus(Id,status));
			var result = await _orderController.ChangeStatus(Id,status);

			var Result = Assert.IsType<OkObjectResult>(result);

		}
		[Fact]
		public async Task Post_ActionExecutes_ReturnOkResult()
		{
			OrderDTO order = orders.First();
			_orderService.Setup(x => x.Create(order));
			var result = await _orderController.Post(order);

			_orderService.Verify(x => x.Create(order), Times.Once);
			var Result = Assert.IsType<OkObjectResult>(result);

		}
	}
}
