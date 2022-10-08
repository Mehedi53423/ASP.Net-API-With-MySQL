using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI01.Data;
using UserAPI01.Models;

namespace UserAPI01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public UsersController(UserAPIDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public UserAPIDbContext DbContext { get; }

        //Get Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var rs = await DbContext.Users.ToListAsync();
            return Ok(rs);
        }

        //Get User
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await DbContext.Users.FindAsync(id);

            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //Add Users
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = addUserRequest.Name,
                Department = addUserRequest.Department,
            };

            await DbContext.Users.AddAsync(user);
            await DbContext.SaveChangesAsync();

            return Ok(user);
        }

        //Update Users
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest updateUserRequest)
        {
            var user = await DbContext.Users.FindAsync(id);

            if (user != null)
            {
                user.Name = updateUserRequest.Name;
                user.Department = updateUserRequest.Department;

                await DbContext.SaveChangesAsync();

                return Ok(user);
            }
            return NotFound();
        }

        //Delete User
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await DbContext.Users.FindAsync(id);

            if(user != null)
            {
                DbContext.Remove(user);
                await DbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
    }
}
