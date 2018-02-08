using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public DateTime DeliveryDate { get; set; }

        public bool OrderStatus { get; set; } = false;

        public int SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; } = new Supplier();

        public virtual List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
