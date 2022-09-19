using Restaurant.Web.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Web.Models
{
    [Table(name: "Customers")]
    public class Customer
    {
        [Key]
        [Required]
        [Display(Name ="CUSTOMER NAME")]
        public int CustomerID { get; set; }
        
        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
       
        [Required]
        public string Phone { get; set; }

       

    }
}