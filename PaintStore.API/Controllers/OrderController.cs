using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintStore.API.DataAccess;
using PaintStore.Models;
using PaintStore.Models.DTOs;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private PaintStoreDbContext _dbContext;
        public OrderController(PaintStoreDbContext paintStoreDb)
        {
            _dbContext = paintStoreDb;
        }

        [HttpGet("{id}")]
        public ActionResult GetOrderById(int id)
        {
            //eager loading
            Order? order = _dbContext.Orders.Include(o => o.User)
                                            .Include(o => o.PaintProducts)    
                                            .FirstOrDefault(o=>o.Id == id);  

            if(order == null)
            {
                return NotFound();
            }

            return Ok(order);  
        }

        //Create a new Order 
        //key-value data ------> {} ------> json
        [HttpPost]
        //我们在直接的使用数据库模型 来 传递http post 请求
        public ActionResult CreateOrder([FromBody] OrderCreateDto orderCreateDto) //auto binding from Json(Http body) to C# model
        {
            // if (order.PaintProducts.Count <= 0)
            // {
            //     throw new Exception("Can not create empty Order");
            // }
            Order order = new Order();
            order.UserId = orderCreateDto.UserId;

            List<PaintProduct> paintProducts = _dbContext.PaintProducts.Where(p=> orderCreateDto.PaintProductIds.Contains(p.Id)).ToList();

            order.PaintProducts = paintProducts;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return Created($"GetOrderById/{order.Id}", order); //when we return C# model, auto binding to JSON format
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderById(int id)
        {
            Order order = new Order();

            if(id == order.Id)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
