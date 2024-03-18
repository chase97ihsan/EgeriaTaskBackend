using EgeriaTaskBackend.Business.Customers;
using EgeriaTaskBackend.Domain.Dto;
using EgeriaTaskBackend.Domain.Entities;
using EgeriaTaskBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace EgeriaTaskBackend.Business.Customers
{
    public class CustomerService:BaseService,ICustomerService
    {
        private readonly EgeriaContext _egeriaContext;
        private readonly IMapper mapper;

        public CustomerService(EgeriaContext egeriaContext, IMapper mapper)
        {
            this._egeriaContext = egeriaContext;
            this.mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetCustomers()
        {
            var customersFromDb = _egeriaContext.Customers.ToList();  //.Include(x => x.Orders)
            var customersMapped = mapper.Map<List<CustomerDto>>(customersFromDb);
            return customersMapped;
        }
    }
}
