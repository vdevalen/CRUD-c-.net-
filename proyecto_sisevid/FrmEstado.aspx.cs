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
    public partial class FrmEstado : System.Web.UI.Page
    {
        protected Estado[] arregloEstado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlEstado objControlEstado = new ControlEstado();
            arregloEstado = objControlEstado.listar();
        }
        protected void BtnGuardarEstado(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdEstado.Text);
            string nom = txtNomEstado.Text;
            Estado objEstado = new Estado(id, nom);
            ControlEstado objControlEstado = new ControlEstado(objEstado);
            objControlEstado.guardar();
            Response.Redirect("FrmEstado.aspx");
        }
        protected void BtnModificarEstado(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdEstado.Text);
            string nom = txtNomEstado.Text;
            Estado objEstado = new Estado(id, nom);
            ControlEstado objControlEstado = new ControlEstado(objEstado);
            objControlEstado.modificar();
            Response.Redirect("FrmEstado.aspx");
        }
        protected void BtnConsultarEstado(object sender, CommandEventArgs e)
        {
            Estado objEstado = new Estado(Int32.Parse(txtIdEstado.Text), "");
            ControlEstado objControlEstado = new ControlEstado(objEstado);
            objEstado = objControlEstado.consultar();
            txtNomEstado.Text = objEstado.Nombre;
        }
        protected void BtnBorrarEstado(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdEstado.Text);
            Estado objEstado = new Estado(id,"");
            ControlEstado objControlTipoIndicador = new ControlEstado(objEstado);
            objControlTipoIndicador.borrar();
            Response.Redirect("FrmEstado.aspx");
        }
    }
}