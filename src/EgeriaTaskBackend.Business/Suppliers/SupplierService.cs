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


namespace EgeriaTaskBackend.Business.Suppliers
{
    public class OrderService:BaseService,ISupplierService
    {
        private readonly EgeriaContext _egeriaContext;
       

        public OrderService(EgeriaContext egeriaContext)
        {
            this._egeriaContext = egeriaContext;
           
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            var suppliersFromDb = _egeriaContext.Suppliers.ToList();

            return suppliersFromDb;
        }
    }
}
