using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDLeonardoMVC.Models.ViewModels
{
    public class EmpleadoViewModel
    {

        public int id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name="Nombre")]
        public string nombre { get; set; }
        [Required]
        [StringLength (50)]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string correo { get; set; }
        public DateTime fecha_registro { get; set; }

        public int edad { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
    }
}