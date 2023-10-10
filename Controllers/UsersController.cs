using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_Test1.Data;
using WebApplication_Test1.Models;

namespace WebApp_Test1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get() { return Ok(await dbContext.Users.ToListAsync()); }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDomain userDomain)
        {
            var user = userDomain;
            user.Id = dbContext.Users.Count() + 1;
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDomain userDomain)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return NotFound();

            user.Name = userDomain.Name;
            user.Email = userDomain.Email;
            user.Id = id;
            user.Role = userDomain.Role;
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            if (dbContext.Users.Count() == 0) NotFound();
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null) NotFound();
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            Ok();
        }
    }
}