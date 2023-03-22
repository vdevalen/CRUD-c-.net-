using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Responsable
    {
        int cedula;
        string nombre;
        string email;

        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }

        public Responsable(int cedula, string nombre, string email)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.email = email;
        }
        public Responsable()
        {
            this.cedula = 0;
            this.nombre = "";
            this.email = "";
        }
    }
}