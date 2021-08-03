using Microsoft.EntityFrameworkCore;
using Order.Business.Abstract;
using OrderApplication.DataAccess;
using OrderApplication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Business.Concrete
{
	public class OrderManager : IOrderService
	{
		private ApplicationDbDataContext _db;
		public OrderManager(ApplicationDbDataContext db)
		{
			_db = db;
		}

		public async Task<bool> ChangeStatus(Guid Id, string status)
		{
			try
			{
				OrderDTO order = await _db.Set<OrderDTO>().FirstOrDefaultAsync(a => a.Id == Id);
				if (order==null)
				{
					return false;
				}
				order.Status = status;
				var updated = _db.Entry(order);
				updated.State = EntityState.Modified;
				await _db.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<Guid> Create(OrderDTO order)
		{
			try
			{
				order.CreateAt = DateTime.Now;
				var added = _db.Entry(order);
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

		public async Task<bool> Delete(Guid Id)
		{
			try
			{

				OrderDTO order = await _db.Set<OrderDTO>().FirstOrDefaultAsync(x => x.Id == Id);
				if (order != null)//Exist Control
				{
					var deleted = _db.Remove(order);
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

		public async Task<List<OrderDTO>> Get()
		{
			return await _db.Set<OrderDTO>().Include(p => p.CustomerDTO).Include(p => p.ProductDTO).Include(a => a.AddressDTO).ToListAsync();
		}

		public async Task<OrderDTO> Get(Guid Id)
		{
			return await _db.Set<OrderDTO>().Include(p => p.CustomerDTO).Include(p => p.ProductDTO).Include(a => a.AddressDTO).FirstOrDefaultAsync(x => x.Id == Id);
		}

		public async Task<bool> Update(OrderDTO order)
		{
			try
			{


				if (await _db.Set<OrderDTO>().AnyAsync(x => x.Id == order.Id))//Exist Control
				{
					order.UpdateAt = DateTime.Now;
					var updated = _db.Entry(order);
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
	}
}
