using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDLeonardoMVC.Models.ViewModels
{
    public class ListEmpleadoViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public DateTime fecha_registro { get; set; }
        public int edad { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
    }
}