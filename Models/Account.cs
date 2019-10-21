using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // public int AccountId { get; set; }
        public string Iban { get; set; }
        public float Balance { get; set; }
        public string Currency { get; set; }
        public int ClientID { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Account> AccountBenef { get; set; }
        public virtual ICollection<Account> AccountOrig { get; set; }
 
    }
}