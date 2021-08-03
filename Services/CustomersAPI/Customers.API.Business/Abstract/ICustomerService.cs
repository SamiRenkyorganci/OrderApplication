using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderApplication.DataAccess.Entities;

namespace Customer.Business.Abstract
{
	public interface ICustomerService
	{

		Task<Guid> Create(CustomerDTO customer);
		Task<bool> Update(CustomerDTO customer);
		Task<bool> Delete(Guid Id);
		Task<List<CustomerDTO>> Get();
		Task<CustomerDTO> Get(Guid Id);
		Task<bool> Validate(Guid Id);

	}
}
