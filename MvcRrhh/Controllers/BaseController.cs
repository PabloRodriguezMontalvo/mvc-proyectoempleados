using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRrhh.Models;
using MvcRrhh.Models.ViewModels;
using Repositorios;

namespace MvcRrhh.Controllers
{
    public class BaseController : Controller
    {
        private DatosEmpleadosEntities _db;

        public BaseController()
        {
            _db=new DatosEmpleadosEntities();
        }

        #region Repositorio

        private IRepositorio<ProyectoViewModel, Proyecto> _RepositorioProyecto;


        protected IRepositorio<ProyectoViewModel, Proyecto> RepositorioProyecto
        {
            get
            {
                if (_RepositorioProyecto == null)
                    _RepositorioProyecto =
                        new Repositorio<ProyectoViewModel, Proyecto>(_db);

                return _RepositorioProyecto;
            }
        }
        private IRepositorio<EmpleadoViewModel, Empleado> _RepositorioEmpleado;


        protected IRepositorio<EmpleadoViewModel, Empleado> RepositorioEmpleado
        {
            get
            {
                if (_RepositorioEmpleado == null)
                    _RepositorioEmpleado =
                        new Repositorio<EmpleadoViewModel, Empleado>(_db);

                return _RepositorioEmpleado;
            }
        }
        #endregion

    }
}