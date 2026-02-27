using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.API.DataAccess;
using PaintStore.Models;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private PaintStoreDbContext _dbContext;
        public UserController(PaintStoreDbContext paintStoreDb)
        {
            _dbContext = paintStoreDb;
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            //Add only mark user to be added
            _dbContext.Users.Add(user);

            //save to db
            _dbContext.SaveChanges();

            return Created("GetUserById",user);
        }
    }
}
