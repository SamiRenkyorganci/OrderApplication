using Customer.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApplication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private ICustomerService _customerService;
		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;

		}

		// GET: api/<CustomerController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var result = await _customerService.Get();
				return Ok(result);

			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			 
		}

		// GET api/<CustomerController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			try
			{
				var result = await _customerService.Get(id);
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
		public async Task<IActionResult> Post([FromBody] CustomerDTO customer)
		{
			if (ModelState.IsValid)
			{
				var result = await _customerService.Create(customer);
				return Ok(result);


			}
			return StatusCode(StatusCodes.Status400BadRequest);
		}

		// PUT api/<CustomerController>/5
		[HttpPut]
		public async Task<IActionResult> Put([FromBody] CustomerDTO customer)
		{
			if (ModelState.IsValid) 
			{
				var result =  await _customerService.Update(customer);
				return Ok(result);


			}
			return StatusCode(StatusCodes.Status400BadRequest);

		}

		[HttpGet]
		[Route("Validate/{id}")]
		public async Task<IActionResult> Validate(Guid id)
		{
			try
			{
				var result=  await _customerService.Validate(id);
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
				var result=  await _customerService.Delete(id);
				return Ok(result);


			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
