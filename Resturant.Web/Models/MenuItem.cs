using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Web.Models
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Menu Item ID")]
        public int MenuItemId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} cannot be empty")]
        [MinLength(2, ErrorMessage = "{0} cannot have lesser than {1} characters")]
        [Display(Name = "Menu Item")]
        public string MenuItemName { get; set; }

        [StringLength(250, ErrorMessage = "{0} cannot be empty")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string ImageURL { get; set; }


        #region Navigation Properties for Category Model

        [Required]
        [Display(Name = "Category")]
        public short CategoryId { get; set; }


        [ForeignKey(nameof(MenuItem.CategoryId))]
        public Category Category { get; set; }


        #endregion


        #region Navigation Properties for OrderDetail Model

        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion

    }
}