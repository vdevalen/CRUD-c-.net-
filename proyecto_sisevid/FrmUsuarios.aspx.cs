using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using proyecto_sisevid.Models;
using proyecto_sisevid.Controllers;

namespace proyecto_sisevid
{
    public partial class FrmUsuarios : System.Web.UI.Page
    {
        protected Usuario[] arregloUsuario = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlUsuario objControlUsuario = new ControlUsuario();
            arregloUsuario = objControlUsuario.listar();
        }

        protected void BtnGuardar(object sender, CommandEventArgs e)
        {
            string nomU = txtNomUsuario.Text;
            string cont = txtContrasena.Text;
            Usuario objUsuario = new Usuario(nomU, cont);
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objControlUsuario.guardar();
            Response.Redirect("FrmUsuarios.aspx");
        }

        protected void BtnModificar(object sender, CommandEventArgs e)
        {
            string nomU = txtNomUsuario.Text;
            string cont = txtContrasena.Text;
            Usuario objUsuario = new Usuario(nomU, cont);
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objControlUsuario.modificar();
            Response.Redirect("FrmUsuarios.aspx");
        }

        protected void BtnConsultar(object sender, CommandEventArgs e)
        {
            Usuario objUsuario = new Usuario(txtNomUsuario.Text,"");
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objUsuario = objControlUsuario.consultar();
            txtContrasena.Text = objUsuario.Contrasena;
        }

        protected void BtnBorrar(object sender, CommandEventArgs e)
        {
            string nomU = txtNomUsuario.Text;
            Usuario objUsuario = new Usuario(nomU, "");
            ControlUsuario objControlUsuario = new ControlUsuario(objUsuario);
            objControlUsuario.borrar();
            Response.Redirect("FrmUsuarios.aspx");
        }
    }
}