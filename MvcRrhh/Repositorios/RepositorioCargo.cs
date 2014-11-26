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
    public class RepositorioCargo:Repositorio<CargoViewModel,Cargo>
    {
        public RepositorioCargo(DbContext context) : base(context)
        {
        }

        public List<CargoViewModel> GetByNombre(String nombre)
        {
            return Get(o => o.nombre.Contains(nombre));
        }
    }
}