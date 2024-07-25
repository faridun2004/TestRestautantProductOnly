using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestRestautantProductOnly.Model.Orders;
using TestRestautantProductOnly.Service;

namespace TestRestautantProductOnly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int userId,[FromBody] OrderCreateDto orderCreateDto)
        {
            var order = await _orderService.CreateOrderAsync(userId,orderCreateDto);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id, userId=order.UserId }, order);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int userId, int id)
        {
            var order = await _orderService.GetOrderByIdAsync(userId,id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }

}
