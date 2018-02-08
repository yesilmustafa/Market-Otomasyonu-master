using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("OrderDetails")]

    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public int Discount { get; set; }

        public string ProductBarcode { get; set; }

        [ForeignKey("ProductBarcode")]
        public virtual Product Product { get; set; } = new Product();

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; } = new Order();
    }
}
