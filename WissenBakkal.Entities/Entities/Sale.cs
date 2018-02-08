using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WissenBakkal.Entitiy.Enums;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("Sales")]
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        public bool SaleStatus { get; set; } = true;

        public EnumPaymentMethod PaymentMethod { get; set; }

        public byte Discount { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; } = new Customer();

        public virtual List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
