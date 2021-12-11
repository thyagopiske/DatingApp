using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;   
        }

        //Retorna lista de usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync(); //LINQ query
        }

        //Retorna um usuario especifico pelo Id
        //Vai chamar esse endpoint se o id do user for parte da url -> api/users/3, por exemplo. id=3
        [HttpGet("{id}")] // "{id}" eh um Route Parameter
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id); //LINQ query
        }

    }
}