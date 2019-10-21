using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Banka.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Banka.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {

        private readonly BankaContext _context;

        public AccountsController(BankaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        [HttpGet("{iban}", Name = "GetAccount")]
        public JsonResult GetByIban(string iban)
        {
            var account = _context.Accounts.FirstOrDefault(t => t.Iban == iban);
            
            if (account == null)
            {
                return Json(new
                {
                    valid = "false"
                });
            }
                return Json(new
                {
                    valid = "true"
                });
        }
    }
}