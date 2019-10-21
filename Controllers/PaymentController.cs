using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Banka.Models;
using System.Linq;
using RestSharp;

namespace Banka.Controllers
{
[Route("api/[controller]")]
    public class PaymentController : Controller
    {

        private readonly BankaContext _context;

        public PaymentController(BankaContext context)
        {
            _context = context;

        }

        /* 
            GET Request => Route => /api/payment 
            Returns the View containing the Form for making a new payment
            Form => POST Request to /api/payments
        */
        public IActionResult Payment()
        {
                return View();
        }

    }
}