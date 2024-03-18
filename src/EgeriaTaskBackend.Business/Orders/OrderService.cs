using AutoMapper;
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


namespace EgeriaTaskBackend.Business.Orders
{
    public class OrderService:BaseService,IOrderService
    {
        private readonly EgeriaContext _egeriaContext;
        private readonly IMapper mapper;


        public OrderService(EgeriaContext egeriaContext, IMapper mapper)
        {
            this._egeriaContext = egeriaContext;
            this.mapper = mapper;
           
        }

        public async Task<OrderDto> GetOrderByObjkeyAsync(string objKey)
        {
            var order= await _egeriaContext.Orders.FirstOrDefaultAsync(o=>o.Objkey.Equals(objKey));
            var orderMapped= mapper.Map<OrderDto>(order);
            return orderMapped;
        }

        public async Task<OrderDto> GetOrderByOrderNoAsync(string orderNo)
        {
            var order = await _egeriaContext.Orders.FirstOrDefaultAsync(x => x.OrderNo.Equals(orderNo));
            var orderMapped = mapper.Map<OrderDto>(order);
            return orderMapped;
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var ordersFromDb = _egeriaContext.Orders.ToList(); //.Include(x=>x.customer)
            var ordersMapped = mapper.Map<List<OrderDto>>(ordersFromDb);
            return ordersMapped;
        }

        public async Task<List<OrderDto>> GetOrdersByCustomerName(string customerName) //ön uçya uppercase yap english e
        {

            var ordersFromDb = await _egeriaContext.Orders
        .Include(x => x.customer)
        .Where(x => x.customer.Name.Replace(" ", "").Equals(customerName.Replace(" ", "").ToLower()))
        .ToListAsync();
            var ordersMapped = mapper.Map<List<OrderDto>>(ordersFromDb);
            return ordersMapped;
        }
    }
}
