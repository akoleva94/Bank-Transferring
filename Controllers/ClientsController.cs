using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Banka.Models;

namespace Banka.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {

        private readonly BankaContext _context;

        public ClientsController(BankaContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        [HttpGet("{id}", Name = "GetClient")]
        public IActionResult GetByClientID(int id)
        {
            var client = _context.Clients.FirstOrDefault(t => t.ClientID == id);

            if (client == null)
            {
                return NotFound();
            }

            return new ObjectResult(client);
        }
    }
}