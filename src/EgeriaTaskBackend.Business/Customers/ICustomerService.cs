using EgeriaTaskBackend.Domain.Dto;
using EgeriaTaskBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeriaTaskBackend.Business.Customers
{
    public interface ICustomerService:IBaseService
    {
       Task<List<CustomerDto>> GetCustomers();
    }
}
