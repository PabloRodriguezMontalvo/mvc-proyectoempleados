using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRrhh.Controllers
{
    public class CargosController : BaseController
    {
        // GET: Cargos
        public ActionResult Index()
        {

            return View(RepositorioCargo.Get());
        }

        public ActionResult BuscarCargo(String nombre)
        {
            var data = RepositorioCargo.GetByNombre(nombre);
            return PartialView("_cargos",data);
        }

          
    }
}