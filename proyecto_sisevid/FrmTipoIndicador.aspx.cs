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
    public partial class FrmTipoIndicador : System.Web.UI.Page
    {
        protected TipoIndicador[] arregloTipoIndicador = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador();
            arregloTipoIndicador = objControlTipoIndicador.listar();
        }
        protected void BtnGuardarTipoIndicador(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdTipoIndicador.Text);
            string nom = txtNomTipoIndicador.Text;
            TipoIndicador objTipoIndicador = new TipoIndicador(id, nom);
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.guardar();
            Response.Redirect("FrmTipoIndicador.aspx");
        }
        protected void BtnModificarTipoIndicador(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdTipoIndicador.Text);
            string nom = txtNomTipoIndicador.Text;
            TipoIndicador objTipoIndicador = new TipoIndicador(id, nom);
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.modificar();
            Response.Redirect("FrmTipoIndicador.aspx");
        }
        protected void BtnConsultarTipoIndicador(object sender, CommandEventArgs e)
        {
            TipoIndicador objTipoIndicador = new TipoIndicador(Int32.Parse(txtIdTipoIndicador.Text), "");
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objTipoIndicador = objControlTipoIndicador.consultar();
            txtNomTipoIndicador.Text = objTipoIndicador.Nombre;
        }
        protected void BtnBorrarTipoIndicador(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdTipoIndicador.Text);
            TipoIndicador objTipoIndicador = new TipoIndicador(id, "");
            ControlTipoIndicador objControlTipoIndicador = new ControlTipoIndicador(objTipoIndicador);
            objControlTipoIndicador.borrar();
            Response.Redirect("FrmTipoIndicador.aspx");
        }
    }
}