using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WissenBakkal.Entitiy.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Display(AutoGenerateField =false)]
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="Kategori ismi boş geçilemez.")]
        [StringLength(50,ErrorMessage ="Kategori ismi 3-50 karekter arasında olmalı.",MinimumLength =3)]
        [Display(Name ="Kategori İsmi")]
        public string CategoryName { get; set; }
        [Display(Name ="Varsayılan KDV Oranı %")]
        [Required(ErrorMessage ="Varsayılan KDV oranını Girmek zorundasınız.")]
        [Range(0,100,ErrorMessage ="KDV 0-100 arası olmalı.")]
        public byte DefaultKDV { get; set; }=0;

        public override string ToString()
        {
            return $"{CategoryName} - %{DefaultKDV}";
        }

    }
}
