using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomyLeRetour.Models
{
    public class Civility : BaseModel
    {
        [Required(ErrorMessage = "Nom Obligatoire")]
        [StringLength(15, ErrorMessage = "Trop long")]
        public string Label { get; set; }
    }
}