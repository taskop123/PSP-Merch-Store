using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PSP_Merch_Store.Models
{
    public class Products
    {
        public int ProductsId { get; set; }
        [Required(ErrorMessage = "Мора да внесете име на продуктот")]
        [Display(Name = "Име на продуктот")]
        public string NameOfProduct { get; set; } // ime na produktot
        [Required(ErrorMessage = "Мора да внесете тип на продуктот")]
        [Display(Name = "Тип на облека")]
        public string ProductType { get; set; }
        [Required(ErrorMessage = "Мора да внесете пол на продуктот")]
        [Display(Name = "Пол")]
        public string Gender { get; set; } // M e masko, Z e zensko
        [Required(ErrorMessage = "Мора да внесете цена на продуктот")]
        [Display(Name = "Цена")]
        public float Price { get; set; } // cena
        [Required(ErrorMessage = "Мора да внесете слика на продуктот")]
        [Display(Name = "Слика")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Image { get; set; } // slika od oblekata
        [Required(ErrorMessage = "Мора да внесете величина на продуктот")]
        [Display(Name = "Величина")]
        public string Size { get; set; } // velicina na oblekata
        [Required(ErrorMessage = "Мора да внесете производител на продуктот")]
        [Display(Name = "Производител")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Мора да внесете боја на продуктот")]
        [Display(Name = "Боја")]
        public string Color { get; set; }
        [Display(Name = "Оцена")]
        public float Rating { get; set; }
        
    }
}