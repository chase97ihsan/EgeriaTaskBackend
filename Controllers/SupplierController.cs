using EgeriaTaskBackend.Business.Suppliers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgeriaTaskBackend.Controllers
{
    [Route("Get/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this._supplierService = supplierService;
        }


        [HttpGet("All")]
        public IActionResult GetSuppliers()
        {
            var suppliers = _supplierService.GetSuppliers();
            return Ok(suppliers);
        }
    }
}
