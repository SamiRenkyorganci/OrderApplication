using Customer.Business.Abstract;
using Microsoft.EntityFrameworkCore;
using OrderApplication.DataAccess;
using OrderApplication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Business.Concrete
{
	public class CustomerManager : ICustomerService
	{
		private ApplicationDbDataContext _db;
		public CustomerManager(ApplicationDbDataContext db)
		{
			_db = db;
		}


		public async Task<Guid> Create(CustomerDTO customer)
		{
			try
			{
				customer.CreateAt = DateTime.Now;
				var added = _db.Entry(customer);
				added.State = EntityState.Added;
				await _db.SaveChangesAsync();
				Guid result = added.Entity.Id;
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		
		}
		public async Task<bool> Update(CustomerDTO customer)
		{
			try
			{
				

				if(await Validate(customer.Id))//Exist Control
				{
					customer.UpdateAt = DateTime.Now;
					var updated = _db.Entry(customer);
					updated.State = EntityState.Modified;
					await _db.SaveChangesAsync();
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public async Task<bool> Delete(Guid Id)
		{
			try
			{

				CustomerDTO customer = await _db.Set<CustomerDTO>().FirstOrDefaultAsync(x => x.Id == Id);
				if (customer!=null)//Exist Control
				{
					var deleted = _db.Remove(customer);
					deleted.State = EntityState.Deleted;
					var deneme = _db.SaveChangesAsync();
					return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		
		}

		public async Task<List<CustomerDTO>> Get()
		{
			return await _db.Set<CustomerDTO>().Include(a=>a.AddressDTO).ToListAsync();
		}

		public async Task<CustomerDTO> Get(Guid Id)
		{
			return await _db.Set<CustomerDTO>().Include(a => a.AddressDTO).FirstOrDefaultAsync(x=>x.Id==Id);

		}
		public async Task<bool> Validate(Guid Id)
		{
			return await _db.Set<CustomerDTO>().AnyAsync(a => a.Id == Id);
		}
	}
}
