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
    public partial class FrmRepresenVisual : System.Web.UI.Page
    {
        protected RepresenVisual[] arregloRepresenVisual = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual();
            arregloRepresenVisual = objControlRepresenVisual.listar();
        }
        protected void BtnGuardarRepresenVisual(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdRepresenVisual.Text);
            string nom = txtNomRepresenVisual.Text;
            RepresenVisual objRepresenVisual = new RepresenVisual(id, nom);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.guardar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }
        protected void BtnModificarRepresenVisual(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdRepresenVisual.Text);
            string nom = txtNomRepresenVisual.Text;
            RepresenVisual objRepresenVisual = new RepresenVisual(id, nom);
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.modificar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }
        protected void BtnConsultarRepresenVisual(object sender, CommandEventArgs e)
        {
            RepresenVisual objRepresenVisual = new RepresenVisual(Int32.Parse(txtIdRepresenVisual.Text), "");
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objRepresenVisual = objControlRepresenVisual.consultar();
            txtNomRepresenVisual.Text = objRepresenVisual.Nombre;
        }
        protected void BtnBorrarRepresenVisual(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdRepresenVisual.Text);
            RepresenVisual objRepresenVisual = new RepresenVisual(id, "");
            ControlRepresenVisual objControlRepresenVisual = new ControlRepresenVisual(objRepresenVisual);
            objControlRepresenVisual.borrar();
            Response.Redirect("FrmRepresenVisual.aspx");
        }
    }
}