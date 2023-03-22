using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using proyecto_sisevid.Models;
//using MiBiblioteca;
namespace proyecto_sisevid.Controllers
{
    public class ControlUsuario
    {
        Usuario objUsuario;
        string baseDeDatos;

        public ControlUsuario(Usuario objUsuario)
        {
            this.objUsuario = objUsuario;
            baseDeDatos = "BD_SISEVID_015224.mdf";
            
        }
        public ControlUsuario()
        {
            this.objUsuario = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar=false;
            string nomUsu = objUsuario.NomUsuario;
            string contra = objUsuario.Contrasena;
            string comandoSQL =
            String.Format("SELECT * FROM tblUsuario WHERE nomUsuario='{0}' AND contrasena='{1}'", nomUsu, contra);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    validar = true;
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return validar;

        }
        public void guardar()
        {
            string nomUsu = objUsuario.NomUsuario;
            string contra = objUsuario.Contrasena;

            string comandoSQL =
            String.Format("INSERT INTO tblUsuario VALUES ('{0}','{1}')", nomUsu, contra);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Usuario consultar()
        {
            string msg = "ok";
            string nomUsu = objUsuario.NomUsuario;
            string comandoSQL =
            String.Format("SELECT * FROM tblUsuario WHERE nomusuario='{0}'", nomUsu);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objUsuario.NomUsuario = objDataSet.Tables[0].Rows[0][0].ToString();
                    objUsuario.Contrasena = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objUsuario;

        }
        public string[] consultarRolesPorUsuario(string nomUsu)
        {
            string msg = "ok";
            string[] listadoRolesDelUsuario = null;
            string comandoSQL =
            String.Format("SELECT fkIdRol FROM tblrol_usuario WHERE fkNomUsuario='{0}'", nomUsu);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    listadoRolesDelUsuario = new string[objDataSet.Tables[0].Rows.Count];
                    int i = 0;
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        listadoRolesDelUsuario[i]= objDataSet.Tables[0].Rows[i][0].ToString();
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return listadoRolesDelUsuario;

        }
        public void modificar()
        {
            string nomUsu = objUsuario.NomUsuario;
            string contra = objUsuario.Contrasena;

            string comandoSQL =
            String.Format("UPDATE tblUsuario SET contrasena='{0}' WHERE nomusuario='{1}'", contra, nomUsu);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            string nomUsu = objUsuario.NomUsuario;
            string comandoSQL =
            String.Format("DELETE FROM tblUsuario WHERE nomusuario='{0}'", nomUsu);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Usuario[] listar()
        {
            string msg = "ok";
            int i;
            Usuario[] arregloUsuario=null;
            string comandoSQL = String.Format("SELECT * FROM tblUsuario");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try { 
            if (objDataSet.Tables[0].Rows.Count > 0)
            {
                i = 0;
                arregloUsuario = new Usuario[objDataSet.Tables[0].Rows.Count];
                while (i < objDataSet.Tables[0].Rows.Count)
                {
                    objUsuario = new Usuario();
                    objUsuario.NomUsuario = objDataSet.Tables[0].Rows[i][0].ToString();
                    objUsuario.Contrasena = objDataSet.Tables[0].Rows[i][1].ToString();

                    arregloUsuario[i] = objUsuario;
                    i++;
                }
                objControlConexion.cerrarBD();
            }
            }
            catch(Exception objException)
            {
                msg = objException.Message;
            }
            return arregloUsuario;
        }
    }
}