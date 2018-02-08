using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Müşteri ismi boş geçilemez.")]
        [StringLength(50, ErrorMessage = "Müşteri ismi 3-50 karekter arasında olmalı.", MinimumLength = 3)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Müşteri telefonu boş geçilemez.")]
        public string Telephone { get; set; }

        public string Address { get; set; }
        [Column(TypeName = "money")]
        public decimal Debt { get; set; } = 0;

        public virtual List<Sale> Sales { get; set; } = new List<Sale>();

        public virtual List<CustomerPayment> CustomerPayments { get; set; } = new List<CustomerPayment>();

        public override string ToString()
        {
            return $"{CustomerName} - {Telephone}";
        }
    }
}
