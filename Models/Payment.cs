using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int Amount { get; set; }
        public string PaymentDate { get; set; }
        public string Reason { get; set; }
        public string IbanOrig { get; set; }
        public string IbanBenef { get; set; }

        [ForeignKey("IbanOrig")]
        public virtual Account AccountOrig { get; set; }
        [ForeignKey("IbanBenef")]
        public virtual Account AccountBenef { get; set; }
   }
}
