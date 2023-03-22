using proyecto_sisevid.Controllers;
using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace proyecto_sisevid
{
    public partial class FrmTipoEvidencia : System.Web.UI.Page
    {
        protected TipoEvidencia[] arregloTipoEvidencia = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia();
            arregloTipoEvidencia = objControlTipoEvidencia.listar();
        }
        protected void BtnGuardarTipoEvidencia(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdTipoEvidencia.Text);
            string nom = txtNomTipoEvidencia.Text;
            TipoEvidencia objTipoEvidencia = new TipoEvidencia(id, nom);
            ControlTipoEvidencia objControlEstado = new ControlTipoEvidencia(objTipoEvidencia);
            objControlEstado.guardar();
            Response.Redirect("FrmTipoEvidencia.aspx");
        }
        protected void BtnModificarTipoEvidencia(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdTipoEvidencia.Text);
            string nom = txtNomTipoEvidencia.Text;
            TipoEvidencia objTipoEvidencia = new TipoEvidencia(id, nom);
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia(objTipoEvidencia);
            objControlTipoEvidencia.modificar();
            Response.Redirect("FrmTipoEvidencia.aspx");
        }
        protected void BtnConsultarTipoEvidencia(object sender, CommandEventArgs e)
        {
            TipoEvidencia objTipoEvidencia = new TipoEvidencia(Int32.Parse(txtIdTipoEvidencia.Text), "");
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia(objTipoEvidencia);
            objTipoEvidencia = objControlTipoEvidencia.consultar();
            txtNomTipoEvidencia.Text = objTipoEvidencia.Nombre;
        }
        protected void BtnBorrarTipoEvidencia(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdTipoEvidencia.Text);
            TipoEvidencia objTipoEvdencia = new TipoEvidencia(id, "");
            ControlTipoEvidencia objControlTipoEvidencia = new ControlTipoEvidencia(objTipoEvdencia);
            objControlTipoEvidencia.borrar();
            Response.Redirect("FrmTipoEvidencia.aspx");
        }


    }
}