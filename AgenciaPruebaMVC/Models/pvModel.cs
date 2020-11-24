using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgenciaPruebaMVC.Models
{
    public class pvModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<int> Cedula { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<int> Codigodeviaje { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}