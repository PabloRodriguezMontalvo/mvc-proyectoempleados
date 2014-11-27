using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRrhh.Models.ViewModels;

namespace MvcRrhh.Controllers
{
    public class EmpleadosController : BaseController
    {

        public ActionResult Alta()
        {
            ViewBag.idCargo = new SelectList(RepositorioCargo.Get(),
                "idCargo","nombre");
            ViewBag.idProyectos = new MultiSelectList(RepositorioProyecto.Get(),
                "idProyecto","nombre");

            return View(new EmpleadoViewModel());
        }

        [HttpPost]
        public ActionResult Alta(EmpleadoViewModel model)
        {
            if (ModelState.IsValid)
            {
                RepositorioEmpleado.Add(model);
                return RedirectToAction("index", "Proyecto");
            }
            return View(model);
        }

        // GET: Empleados
        public ActionResult ListadoEmpleados()
        {
            return View(RepositorioEmpleado.Get());
        }
        [HttpPost]
        public ActionResult EmpleadosPorCargo(int id)
        {
            var data = RepositorioEmpleado.GetByCargo(id);
            return Json(data);
        }
    }
}