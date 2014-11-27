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

        public override EmpleadoViewModel Add(EmpleadoViewModel modelo)
        {
            var proyectos = Context.Set<Proyecto>().Where(o => modelo.idProyectos.Contains(o.idProyecto))
                .ToList();

            var datos = modelo.ToBaseDatos();
            datos.Proyecto = proyectos;

            DbSet.Add(datos);
            Context.SaveChanges();
            modelo.FromBaseDatos(datos);

            return modelo;

        }
    }
}