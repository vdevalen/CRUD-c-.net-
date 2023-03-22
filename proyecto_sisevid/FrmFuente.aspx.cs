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
    public partial class FrmFuente : System.Web.UI.Page
    {
        protected Fuente[] arregloFuente = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlFuente objControlFuente = new ControlFuente();
            arregloFuente = objControlFuente.listar();
        }
        protected void BtnGuardarFuente(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdFuente.Text);
            string nom = txtNomFuente.Text;
            Fuente objFuente = new Fuente(id, nom);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.guardar();
            Response.Redirect("FrmFuente.aspx");
        }
        protected void BtnModificarFuente(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdFuente.Text);
            string nom = txtNomFuente.Text;
            Fuente objFuente = new Fuente(id, nom);
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.modificar();
            Response.Redirect("FrmFuente.aspx");
        }
        protected void BtnConsultarFuente(object sender, CommandEventArgs e)
        {
            Fuente objFuente = new Fuente(Int32.Parse(txtIdFuente.Text), "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objFuente = objControlFuente.consultar();
            txtNomFuente.Text = objFuente.Nombre;
        }
        protected void BtnBorrarFuente(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdFuente.Text);
            Fuente objFuente = new Fuente(id, "");
            ControlFuente objControlFuente = new ControlFuente(objFuente);
            objControlFuente.borrar();
            Response.Redirect("FrmFuente.aspx");
        }
    }
}