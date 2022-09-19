using Resturant.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Web.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }



        


        #region Navigation Properties to Order Model

        [Required]
        public int OrderNumber { get; set; }


        [ForeignKey(nameof(OrderDetail.OrderNumber))]
        public Order Order { get; set; }

        #endregion


        #region Navigation Properties to MenuItem Model 

        [Required]
        public int MenuItemId { get; set; }


        [ForeignKey(nameof(OrderDetail.MenuItemId))]
        public MenuItem MenuItem { get; set; }

        #endregion


        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Total
        {
            get
            {
                return Quantity * Price;
            }
        }

    }
}