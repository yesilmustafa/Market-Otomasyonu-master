using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("Suppliers")]

    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "Firma ismi boş geçilemez.")]
        [StringLength(50, ErrorMessage = "Firma ismi 3-50 karekter arasında olmalı.", MinimumLength = 3)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "İlgiliKisi ismi boş geçilemez.")]
        [StringLength(50, ErrorMessage = "İlgiliKisi ismi 3-50 karekter arasında olmalı.", MinimumLength = 3)]
        public string ContactName { get; set; }

        public string Address { get; set; }
        [Required(ErrorMessage = "Telefon boş geçilemez.")]
        public string Telephone { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();

        public override string ToString()
        {
            return $"{CompanyName} - {ContactName} - {Telephone}";
        }
    }
}
