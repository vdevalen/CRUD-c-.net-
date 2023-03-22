using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class UnidadDeMedicion
    {
        int id;
        string descripcion;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public UnidadDeMedicion(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }
        public UnidadDeMedicion()
        {
            this.id = 0;
            this.descripcion = "";
        }
    }
}