using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Models
{
    public class RolUsuario
    {
        string fkNomUsuario;
        int fkIdRol;

        public string FkNomUsuario { get => fkNomUsuario; set => fkNomUsuario = value; }
        public int FkIdRol { get => fkIdRol; set => fkIdRol = value; }

        public RolUsuario(string fkNomUsuario, int fkIdRol)
        {
            this.fkNomUsuario = fkNomUsuario;
            this.fkIdRol = fkIdRol;
        }
        public RolUsuario()
        {
            this.fkNomUsuario = "";
            this.fkIdRol = 0;
        }

    }
}