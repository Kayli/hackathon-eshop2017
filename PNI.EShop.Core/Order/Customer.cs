using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PNI.EShop.Core.Order
{
    public class Customer
    {
        [Required(ErrorMessage = "First Name Required")]
        [StringLength(50, ErrorMessage = "Name too long, must be under 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(50, ErrorMessage = "Name too long, must be under 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address Name Required")]
        [StringLength(200, ErrorMessage = "Address too long, must be under 200 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "PostalCode Name Required")]
        [StringLength(6, ErrorMessage = "A Canadian postal code is 6 characters!")]
        [RegularExpression("^([a-zA-Z][0-9]){3}$", ErrorMessage = "Not a valid Canadian Postal Code")]
        public string PostalCode { get; set; }
    }
}
