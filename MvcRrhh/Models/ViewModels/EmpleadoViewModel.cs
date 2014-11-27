using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repositorios;

namespace MvcRrhh.Models.ViewModels
{
    public class EmpleadoViewModel:IViewModel<Empleado>
    {
        public int idEmpleado { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [DisplayName("DNI")]
        public string dni { get; set; }
        [DisplayName("Cargo")]
        public int idCargo { get; set; }
        [DisplayName("Salario")]
        public Nullable<decimal> salario { get; set; }
        [DisplayName("Proyectos")]
        public List<int> idProyectos { get; set; }

        public Empleado ToBaseDatos()
        {
            var model = new Empleado()
            {
                idCargo = idCargo,
                idEmpleado = idEmpleado,
                nombre = nombre,
                dni = dni,
                salario = salario

            };
            return model;
        }

        public void FromBaseDatos(Empleado model)
        {
            idCargo = model.idCargo;
            idEmpleado = model.idEmpleado;
            nombre = model.nombre;
            dni = model.dni;
            salario = model.salario;

            try
            {
                idProyectos = model.Proyecto.
                    Select(o => o.idProyecto).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateBaseDatos(Empleado model)
        {
            model.idCargo = idCargo;
            model.idEmpleado = idEmpleado;
            model.nombre = nombre;
            model.dni = dni;
            model.salario = salario;
        }

        public int[] GetPk()
        {
            return new[] {idEmpleado};
        }
    }
}