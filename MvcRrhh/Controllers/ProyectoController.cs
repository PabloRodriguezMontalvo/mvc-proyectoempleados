using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRrhh.Models.ViewModels;

namespace MvcRrhh.Controllers
{
    public class ProyectoController : BaseController
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            var data = RepositorioProyecto.Get();
            return View(data);
        }

        #region Alta
        public ActionResult NuevoProyecto()
        {
            return View(new ProyectoViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoProyecto(ProyectoViewModel model)
        {
            if (ModelState.IsValid)
            {
                RepositorioProyecto.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        #endregion
    }
}