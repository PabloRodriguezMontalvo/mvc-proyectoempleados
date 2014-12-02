using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRrhh.Models.ViewModelServicios
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public int idCargo { get; set; }
        public Nullable<decimal> salario { get; set; }

        public String NombreCargo { get; set; }

        public List<Proyecto> Proyectos { get; set; }
    }
}