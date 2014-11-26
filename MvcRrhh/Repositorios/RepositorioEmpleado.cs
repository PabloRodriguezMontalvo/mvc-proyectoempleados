using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcRrhh.Models;
using MvcRrhh.Models.ViewModels;
using Repositorios;

namespace MvcRrhh.Repositorios
{
    public class RepositorioEmpleado:Repositorio<EmpleadoViewModel,Empleado>
    {
        public RepositorioEmpleado(DbContext context) : base(context)
        {
        }

        public List<EmpleadoViewModel> GetByCargo(int idCargo)
        {
            return Get(o => o.idCargo == idCargo);
        }
    }
}