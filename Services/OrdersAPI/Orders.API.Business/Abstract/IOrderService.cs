using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderApplication.DataAccess.Entities;

namespace Order.Business.Abstract
{
	public interface IOrderService
	{

		Task<Guid> Create(OrderDTO order);
		Task<bool> Update(OrderDTO order);
		Task<bool> Delete(Guid Id);
		Task<List<OrderDTO>> Get();
		Task<OrderDTO> Get(Guid Id);
		Task<bool> ChangeStatus(Guid Id,string status);

	}
}
