using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositorios;

namespace MvcRrhh.Models.ViewModels
{
    public class EmpleadoViewModel:IViewModel<Empleado>
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public int idCargo { get; set; }
        public Nullable<decimal> salario { get; set; }
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