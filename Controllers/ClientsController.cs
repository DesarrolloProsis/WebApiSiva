using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiSiva.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApiSiva.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly GTDbContext _context;
        public ClientsController(GTDbContext context)
        {
            _context = context;
        }

        // GET api/clients/190311100051
        [HttpGet("{NumClient}")]
        public async Task<IActionResult> GetValues(string NumClient)
        {
            var values = await _context.Clientes.FirstOrDefaultAsync(x => x.NumCliente == NumClient);
            return Ok(values);
        }

        
        // GET api/clients/190311100051
        [HttpGet("{NumClient}")]
        public async Task<IActionResult> GetCuentasTag(string NumClient)
        {
            var values = await _context.Clientes.FirstOrDefaultAsync(x => x.NumCliente == NumClient);
            return Ok(values);
        }
    }
}