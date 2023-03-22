using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Autor
    {
        int id;
        string ident;
        string nombre;

        public int Id { get => id; set => id = value; }
        public string Ident { get => ident; set => ident = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Autor(int id, string ident, string nombre)
        {
            this.id = id;
            this.ident = ident;
            this.nombre = nombre;
        }
        public Autor()
        {
            this.id = 0;
            this.ident = "";
            this.nombre = "";
        }
    }
}