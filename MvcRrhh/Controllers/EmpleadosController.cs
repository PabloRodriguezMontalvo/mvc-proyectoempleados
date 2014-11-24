using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRrhh.Controllers
{
    public class EmpleadosController : BaseController
    {
        // GET: Empleados
        public ActionResult ListadoEmpleados()
        {
            return View(RepositorioEmpleado.Get());
        }
    }
}