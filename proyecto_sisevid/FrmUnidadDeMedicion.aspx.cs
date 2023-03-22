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
    public partial class FrmUnidadDeMedicion : System.Web.UI.Page
    {
        protected UnidadDeMedicion[] arregloUnidadDeMedicion = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            ControlUnidadDeMedicion objControlUnidadDeMedicion = new ControlUnidadDeMedicion();
            arregloUnidadDeMedicion = objControlUnidadDeMedicion.listar();
        }
        protected void BtnGuardarUnidadDeMedicion(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdMedicion.Text);
            string descripcion = txtDescripcionUnidadDeMedicion.Text;
            UnidadDeMedicion objUnidadDeMedicion = new UnidadDeMedicion(id, descripcion);
            ControlUnidadDeMedicion objControlUnidadDeMedicion = new ControlUnidadDeMedicion(objUnidadDeMedicion);
            objControlUnidadDeMedicion.guardar();
            Response.Redirect("FrmUnidadDeMedicion.aspx");
        }
        protected void BtnModificarUnidadDeMedicion(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdMedicion.Text);
            string descripcion = txtDescripcionUnidadDeMedicion.Text;
            UnidadDeMedicion objUnidadDeMedicion = new UnidadDeMedicion(id, descripcion);
            ControlUnidadDeMedicion objControlUnidadDeMedicion = new ControlUnidadDeMedicion(objUnidadDeMedicion);
            objControlUnidadDeMedicion.modificar();
            Response.Redirect("FrmUnidadDeMedicion.aspx");
        }
        protected void BtnConsultarUnidadDeMedicion(object sender, CommandEventArgs e)
        {
            UnidadDeMedicion objUnidadDeMedicion = new UnidadDeMedicion(Int32.Parse(txtIdMedicion.Text), "");
            ControlUnidadDeMedicion objControlUnidadDeMedicion = new ControlUnidadDeMedicion(objUnidadDeMedicion);
            objUnidadDeMedicion = objControlUnidadDeMedicion.consultar();
            txtDescripcionUnidadDeMedicion.Text = objUnidadDeMedicion.Descripcion;
        }
        protected void BtnBorrarUnidadDeMedicion(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdMedicion.Text);
            UnidadDeMedicion objUnidadDeMedicion = new UnidadDeMedicion(id, "");
            ControlUnidadDeMedicion objControlUnidadDeMedicion = new ControlUnidadDeMedicion(objUnidadDeMedicion);
            objControlUnidadDeMedicion.borrar();
            Response.Redirect("FrmUnidadDeMedicion.aspx");
        }
    }
}