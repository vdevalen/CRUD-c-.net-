//using MiBiblioteca;
using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlRol
    {
        Rol objRol;
        string baseDeDatos;

        public ControlRol(Rol objRol)
        {
            this.objRol = objRol;
            baseDeDatos = "BD_SISEVID_015224.mdf";

        }
        public ControlRol()
        {
            this.objRol = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public void guardar()
        {
            string nom = objRol.Nombre;
            int id = objRol.Id;

            string comandoSQL =
            String.Format("INSERT INTO tblRol VALUES ({0},'{1}')", id, nom);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Rol consultar()
        {
            string msg = "ok";
            int id = objRol.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tblRol WHERE id={0}", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                objRol.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                objRol.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objRol;

        }
        public void modificar()
        {
            string nom = objRol.Nombre;
            int id = objRol.Id;

            string comandoSQL =
            String.Format("UPDATE tblRol SET nombre='{0}' WHERE id={1}", nom, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objRol.Id;
            string comandoSQL =
            String.Format("DELETE FROM tblRol WHERE id={0}", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Rol[] listar()
        {
            string msg = "ok";
            int i;
            Rol[] arregloRol = null;
            string comandoSQL = String.Format("SELECT * FROM tblRol");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloRol = new Rol[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objRol = new Rol();
                        objRol.Id = Convert.ToInt32(objDataSet.Tables[0].Rows[i][0].ToString());
                        objRol.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloRol[i] = objRol;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch(Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return arregloRol;
        }
    }
}