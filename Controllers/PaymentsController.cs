using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Banka.Models;
using System.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace Banka.Controllers
{
[Route("api/[controller]")]
    public class PaymentsController : Controller
    {

        private readonly BankaContext _context;

        public PaymentsController(BankaContext context)
        {
            _context = context;
        }

        public T Get<T>()
                {
                    var request = (HttpWebRequest)WebRequest.Create("http://localhost:5000/api/accounts/GAD1");
                    request.Method = "GET";
                    request.KeepAlive = true;

                    T result = default(T);
                    using (var response = request.GetResponse())
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                string responseText = reader.ReadToEnd();
                                result = JsonConvert.DeserializeObject<T>(responseText);
                            }
                        }
                    }
                    return result;
                }
        
        public Object GetAll()
        {
            return Ok(Get<Object>());
        }


        /* 
            GET Request => Route => /api/payments
            returns all payments
        */
/*         [HttpGet (Name = "GetAll")]
        public IActionResult GetAll()
        {
            var payments = _context.Payments.ToList();

            return View(payments);
        } */

        /* 
            GET Request => Route => /api/payments/{iban}
            returns the payments for specific iban passed as a string
        */
        [HttpGet("{iban}", Name = "GetPayment")]
        public IActionResult GetByIban(string iban)
        {
            var payment = _context.Payments.Where(t => t.IbanOrig == iban || t.IbanBenef == iban).ToList();
            
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        /* 
            POST Request => Route => /api/payments
            Makes a new payment with parameters passed from the View Payment.cshtml
        */
        [HttpPost(Name = "MakePayment")]
        public IActionResult MakePayment([Bind("Amount, IbanBenef, IbanOrig, PaymentDate, Reason")]  /* [FromBody] */ Payment payment, int Amount, string IbanBenef, string IbanOrig, string PaymentDate, string Reason)
        {
            // TODO: Generate PaymentDate (DateTime.Now?)
            Amount = payment.Amount;
            IbanBenef = payment.IbanBenef;
            IbanOrig = payment.IbanOrig;
            PaymentDate = payment.PaymentDate;
            Reason = payment.Reason;

            bool localOriginator = false;
            bool localBeneficient = false;

            if (IbanOrig.ToLower().Substring(0, 3) == "GAD")
            {
                localOriginator = true;
            }


            if (IbanBenef.ToLower().Substring(0, 3) == "GAD")
            {
                localBeneficient = true;
            }

            if (localOriginator && !localBeneficient)
            {
                
            }
            
            if (ModelState.IsValid)
            {
               /*  _context.Payments.Add(payment);
                _context.SaveChanges();
 */         
                 return Json(new
                {
                    result = "OK"
                });
            }

            return Json(new
                {
                    result = "fail",
                    error_code = "500",
                    error_message = "Error Processing Payment"
                });
        }
    }
}