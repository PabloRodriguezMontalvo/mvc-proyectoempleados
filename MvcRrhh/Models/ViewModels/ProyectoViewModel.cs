using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Repositorios;

namespace MvcRrhh.Models.ViewModels
{
    public class ProyectoViewModel: IViewModel<Proyecto>
    {
        public int idProyecto { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string cliente { get; set; }
        [Required]
        public string descripcion { get; set; }
    
        public Proyecto ToBaseDatos()
        {
            var model = new Proyecto()
            {
                idProyecto = idProyecto,
                nombre = nombre,
                cliente = cliente,
                descripcion = descripcion
            };
            return model;
        }

        public void FromBaseDatos(Proyecto model)
        {
            idProyecto = model.idProyecto;
            nombre = model.nombre;
            cliente = model.cliente;
            descripcion = model.descripcion;
        }

        public void UpdateBaseDatos(Proyecto model)
        {
            model.idProyecto = idProyecto;
            model.nombre = nombre;
            model.cliente = cliente;
            model.descripcion = descripcion;
        }

        public int[] GetPk()
        {
            return new[] {idProyecto};
        }
    }
}