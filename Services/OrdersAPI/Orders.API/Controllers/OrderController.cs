using Order.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApplication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private IOrderService _orderService;
		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;

		}
		// GET: api/<OrderController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var result = await _orderService.Get();
				return Ok(result);

			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}

		}

		// GET api/<OrderController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			try
			{
				var result = await _orderService.Get(id);
				if (result == null)
				{
					return NotFound();
				}
				return Ok(result);

			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}

		}
		// POST api/<CustomerController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] OrderDTO order)
		{
			if (ModelState.IsValid)
			{
				var result = await _orderService.Create(order);
				return Ok(result);

			}
			return StatusCode(StatusCodes.Status400BadRequest);
		}

		// PUT api/<CustomerController>/5
		[HttpPut]
		public async Task<IActionResult> Put([FromBody] OrderDTO order)
		{
			if (ModelState.IsValid)
			{
				var result = await _orderService.Update(order);
				return Ok(result);

			}
			return StatusCode(StatusCodes.Status400BadRequest);

		}
		[HttpPut]
		[Route("ChangeStatus/{id}/{status}")]
		public async Task<IActionResult> ChangeStatus(Guid id,string status)
		{
			try
			{
				var result = await _orderService.ChangeStatus(id,status);
				return Ok(result);

			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}

		}
		// DELETE api/<CustomerController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				var result = await _orderService.Delete(id);
				return Ok(result);

			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
