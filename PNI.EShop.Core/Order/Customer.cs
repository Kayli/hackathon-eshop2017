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
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "Name is too long, must be under 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Name is too long, must be under 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address is too long, must be under 200 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Postal code is required")]
        [StringLength(6, ErrorMessage = "A Canadian postal code is 6 characters!")]
        [RegularExpression("^([a-zA-Z][0-9]){3}$", ErrorMessage = "Not a valid Canadian Postal Code")]
        public string PostalCode { get; set; }
    }
}
