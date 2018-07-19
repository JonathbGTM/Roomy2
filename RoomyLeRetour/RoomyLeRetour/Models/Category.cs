using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomyLeRetour.Models
{
    public class Category : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(50)]
        [Display(Name = "Libellé de catégorie")]
        public string Name { get; set; }
    }
}