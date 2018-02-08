using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public string ProductBarcode { get; set; }
        [Required(ErrorMessage = "Ürün ismi boş geçilemez.")]
        [StringLength(50, ErrorMessage = "Ürün ismi 3-50 karekter arasında olmalı.", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Required]
        public bool DisContinued { get; set; }

        public int KDV { get; set; }

        public byte[] Picture { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; } = new Category();

        public virtual List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

        public virtual List<OrderDetail> OrdersDetails { get; set; } = new List<OrderDetail>();

        public override string ToString()
        {
            return $"{ProductName} - {UnitPrice:C2}";
        }
    }

}
