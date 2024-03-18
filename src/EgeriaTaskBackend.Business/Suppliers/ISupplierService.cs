using EgeriaTaskBackend.Domain.Dto;
using EgeriaTaskBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeriaTaskBackend.Business.Suppliers
{
    public interface ISupplierService:IBaseService
    {
       Task<List<Supplier>> GetSuppliers();
    }
}
