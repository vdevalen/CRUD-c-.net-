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
    public partial class FrmAutor : System.Web.UI.Page
    {
        protected Autor[] arregloAutor = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlAutor objControlAutor = new ControlAutor();
            arregloAutor = objControlAutor.listar();
        }

        protected void BtnGuardarAutor(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdAutor.Text);
            string nom = txtNomAutor.Text;
            string ident = txtIdent.Text; //falta añadir esto
            Autor objAutor = new Autor(id, ident, nom);
            ControlAutor objControlAutor = new ControlAutor(objAutor);
            objControlAutor.guardar();
            Response.Redirect("FrmAutor.aspx");
        }
        protected void BtnModificarAutor(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdAutor.Text);
            string nom = txtNomAutor.Text;
            string ident = txtIdent.Text; //falta añadir esto
            Autor objAutor = new Autor(id, ident, nom);
            ControlAutor objControlAutor = new ControlAutor(objAutor);
            objControlAutor.modificar();
            Response.Redirect("FrmAutor.aspx");
        }
        protected void BtnConsultarAutor(object send, CommandEventArgs e)
        {
            Autor objAutor = new Autor(Int32.Parse(txtIdAutor.Text), "", "");
            ControlAutor objControlAutor = new ControlAutor(objAutor);
            objAutor = objControlAutor.consultar();
            txtNomAutor.Text = objAutor.Nombre;
        }
        protected void BtnBorrarAutor(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtIdAutor.Text);
            Autor objAutor = new Autor(id, "", "");
            ControlAutor objControlAutor = new ControlAutor(objAutor);
            objControlAutor.borrar();
            Response.Redirect("FrmAutor.aspx");
        }
    }
}