using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashComp6.Shared.Models
{
    public class Contact
    {
        //Id for table
        public int Id { get; set; }

        //RequireNames
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";

        [Required]
        [MinLength(3)]
        public string CompanyName { get; set; } = "";

        public bool FinacialAdvice { get; set; } = false;

        public bool FreightForwarding { get; set; } = false;

        public bool InventoryAccounting { get; set; } = false;

        public string Remarks { get; set; } = "";

        public DateTime ContactSubmitted { get; set; } = DateTime.Now;

        [EmailAddress]
        public string Email { get; set; } = "";

        [Phone]
        public string PhoneNumber { get; set; } = "";

        [Url]
        public string Website { get; set; } = "";

        public DateTime? RespondedTo { get; set; } = null;
        

    }
}
