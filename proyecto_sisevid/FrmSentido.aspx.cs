using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto_sisevid
{
    public partial class FrmSentido : System.Web.UI.Page
    {
        protected Sentido[] arregloSentido = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlSentido objControlSentido = new ControlSentido();
            arregloSentido = objControlSentido.listar();
        }
        protected void BtnGuardarSentido(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdSentido.Text);
            string nom = txtNomSentido.Text;
            Sentido objSentido = new Sentido(id, nom);
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.guardar();
            Response.Redirect("FrmSentido.aspx");
        }
        protected void BtnModificarSentido(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdSentido.Text);
            string nom = txtNomSentido.Text;
            Sentido objSentido = new Sentido(id, nom);
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.modificar();
            Response.Redirect("FrmSentido.aspx");
        }
        protected void BtnConsultarSentido(object sender, CommandEventArgs e)
        {
            Sentido objSentido = new Sentido(Int32.Parse(txtIdSentido.Text), "");
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objSentido = objControlSentido.consultar();
            txtNomSentido.Text = objSentido.Nombre;
        }
        protected void BtnBorrarSentido(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdSentido.Text);
            Sentido objSentido = new Sentido(id, "");
            ControlSentido objControlSentido = new ControlSentido(objSentido);
            objControlSentido.borrar();
            Response.Redirect("FrmSentido.aspx");
        }
    }
}