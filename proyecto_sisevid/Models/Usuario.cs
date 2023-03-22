using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class Usuario
    {
        string nomUsuario;
        string contrasena;

        public string NomUsuario { get => nomUsuario; set => nomUsuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }

        public Usuario(string nomUsuario, string contrasena)
        {
            this.nomUsuario = nomUsuario;
            this.contrasena = contrasena;
        }
        public Usuario()
        {
            this.nomUsuario = "";
            this.contrasena = "";
        }

    }
}