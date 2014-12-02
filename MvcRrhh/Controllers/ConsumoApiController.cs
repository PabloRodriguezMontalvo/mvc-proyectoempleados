using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcRrhh.Models.ViewModelServicios;
using MvcRrhh.Servicios;

namespace MvcRrhh.Controllers
{
    public class ConsumoApiController : Controller
    {
        IServicios<Empleado> servicios = 
            new Servicios<Empleado>("http://localhost:54325/v1/empleados"); 

        // GET: ConsumoApi
        public ActionResult Index()
        {
            var lista = servicios.Get();
            return View(lista);
        }

        public ActionResult Alta()
        {
            return View(new Empleado());
        }
        [HttpPost]
        public async Task<ActionResult> Alta(Empleado model)
        {

           await servicios.Add(model);

            return RedirectToAction("Index");
        }
    }
}