using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("SaleDetails")]
    public class SaleDetail
    {
        [Key]
        public int SaleDetailID { get; set; }

        public int SaleID { get; set; }

        public string ProductBarcode { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        [ForeignKey("SaleID")]
        public virtual Sale Sale { get; set; } = new Sale();

        [ForeignKey("ProductBarcode")]
        public virtual Product Product { get; set; } = new Product();

    }
}
