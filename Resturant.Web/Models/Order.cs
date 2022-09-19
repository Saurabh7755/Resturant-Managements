using Resturant.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Web.Models
{
    [Table("Orders")]
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Table Number")]
        public int OrderNumber { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey(nameof(Order.CustomerID))]
        public Customer Customer { get; set; }


        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OrderDateTime { get; set; }


        #region Navigation Properties to the OrderDetail Model

        public ICollection<OrderDetail> OrderDetails { get; set; }

       
        #endregion

    }
}