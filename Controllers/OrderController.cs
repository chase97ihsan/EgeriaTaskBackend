using EgeriaTaskBackend.Business.Orders;
using EgeriaTaskBackend.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgeriaTaskBackend.Controllers
{
    [Route("Get/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }


        [HttpGet("All")]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("ByOrderNo/{orderNo}")]
      
        public async Task<IActionResult> GetOrderByOrderNo(string orderNo)
                {
            var order = await _orderService.GetOrderByOrderNoAsync(orderNo);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("ByObjkey/{objKey}")]

        public async Task<IActionResult> GetOrderByObjkey(string objKey)
        {
            var order = await _orderService.GetOrderByObjkeyAsync(objKey);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("ByCustomerName/{customerName}")]

        public async Task<IActionResult> GetOrdersByCustomerName(string customerName)
        {
            var order = await _orderService.GetOrdersByCustomerName(customerName);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);

        }

        [HttpPost("SendOrderInformationToEmail/{email}")]

        public async Task<IActionResult> GetOrderByObjkey([FromBody]string orderNo, string objKey)
        {
            var order = await _orderService.GetOrderByObjkeyAsync(objKey);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
