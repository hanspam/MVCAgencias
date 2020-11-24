using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgenciaPruebaMVC.Models
{
    public class PersonaModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Cedula { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Direccion { get; set; }
        public Nullable<long> Telefono { get; set; }
    }
}