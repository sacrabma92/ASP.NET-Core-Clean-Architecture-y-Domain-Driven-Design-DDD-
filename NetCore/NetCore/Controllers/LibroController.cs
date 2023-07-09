using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore.Entities;
using System.Collections;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibroController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ICollection<Libro>> GetAll()
        {
            return await context.Libro.OrderBy(x => x.Titulo).ToListAsync();
        }
    }
}
