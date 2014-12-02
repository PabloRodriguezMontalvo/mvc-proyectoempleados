using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRrhh.Models.ViewModelServicios
{
    public class Proyecto
    {
        public int idProyecto { get; set; }
        public string nombre { get; set; }
        public string cliente { get; set; }
        public string descripcion { get; set; }
    }
}