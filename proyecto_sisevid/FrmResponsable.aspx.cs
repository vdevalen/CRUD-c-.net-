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
    public partial class FrmResponsable : System.Web.UI.Page
    {
        protected Responsable[] arregloResponsable = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlResponsable objControlResponsable = new ControlResponsable();
            arregloResponsable = objControlResponsable.listar();
        }
        protected void BtnGuardarResponsable(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtCedulaResponsable.Text); //modificar todo esto
            string nom = txtNomResponsable.Text;
            string email = txtEmailResponsable.Text;
            Responsable objResponsable = new Responsable(id, nom, email);
            ControlResponsable objControlResponsable = new ControlResponsable(objResponsable);
            objControlResponsable.guardar();
            Response.Redirect("FrmResponsable.aspx");
        }
        protected void BtnModificarResponsable(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(txtCedulaResponsable.Text); //modificar todo esto
            string nom = txtNomResponsable.Text;
            string email = txtEmailResponsable.Text;
            Responsable objResponsable = new Responsable(id, nom, email);
            ControlResponsable objControlResponsable = new ControlResponsable(objResponsable);
            objControlResponsable.modificar();
            Response.Redirect("FrmResponsable.aspx");
        }
        protected void BtnConsultarResponsable(object sender, CommandEventArgs e)
        {
            Responsable objResponsable = new Responsable(Int32.Parse(txtCedulaResponsable.Text), "", "");
            ControlResponsable objControlResponsable = new ControlResponsable(objResponsable);
            objResponsable = objControlResponsable.consultar();
            txtNomResponsable.Text = objResponsable.Nombre;
        }
        protected void BtnBorrarResponsable(object sender, CommandEventArgs e)
        {
            int cedula = Int32.Parse(txtCedulaResponsable.Text);
            Responsable objResponsable = new Responsable(cedula, "", "");
            ControlResponsable objControlResponsable = new ControlResponsable(objResponsable);
            objControlResponsable.borrar();
            Response.Redirect("FrmResponsable.aspx");
        }
    }
}