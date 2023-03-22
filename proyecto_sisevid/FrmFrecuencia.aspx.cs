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
    public partial class FrmFrecuencia : System.Web.UI.Page
    {
        protected Frecuencia[] arregloFrecuencia = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia();
            arregloFrecuencia = objControlFrecuencia.listar();
        }
        protected void BtnGuardarFrecuencia(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdFrecuencia.Text);
            string descripcion = txtDescripcionFrecuencia.Text;
            Frecuencia objFrecuencia = new Frecuencia(id, descripcion);
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objControlFrecuencia.guardar();
            Response.Redirect("FrmFrecuencia.aspx");
        }
        protected void BtnModificarFrecuencia(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdFrecuencia.Text);
            string descripcion = txtDescripcionFrecuencia.Text;
            Frecuencia objFrecuencia = new Frecuencia(id, descripcion);
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objControlFrecuencia.modificar();
            Response.Redirect("FrmFrecuencia.aspx");
        }
        protected void BtnConsultarFrecuencia(object sender, CommandEventArgs e)
        {
            Frecuencia objFrecuencia = new Frecuencia(Int32.Parse(txtIdFrecuencia.Text), "");
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objFrecuencia = objControlFrecuencia.consultar();
            txtDescripcionFrecuencia.Text = objFrecuencia.Descripcion;
        }
        protected void BtnBorrarFrecuencia(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdFrecuencia.Text);
            Frecuencia objFrecuencia = new Frecuencia(id, "");
            ControlFrecuencia objControlFrecuencia = new ControlFrecuencia(objFrecuencia);
            objControlFrecuencia.borrar();
            Response.Redirect("FrmFrecuencia.aspx");
        }
    }
}