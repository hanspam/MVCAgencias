using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgenciaPruebaMVC.Models
{
    public class ViajeModel
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int CodigodeViaje { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<int> NumeroPlazas { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string LugarOrigen { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Nullable<decimal> Precio { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Destino { get; set; }
    }
}