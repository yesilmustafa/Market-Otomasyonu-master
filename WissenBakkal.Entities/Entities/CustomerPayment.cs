using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("CustomerPayments")]
    public class CustomerPayment
    {
        [Key]
        public int CustomerPaymentID { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]

        public virtual Customer Customer { get; set; } = new Customer();
    }
}
