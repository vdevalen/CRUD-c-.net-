using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlAutor
    {
        Autor objAutor;
        string baseDeDatos;

        public ControlAutor(Autor objAutor)
        {
            this.objAutor = objAutor;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlAutor()
        {
            this.objAutor = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }

        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objAutor.Id;
            string nombre = objAutor.Nombre;
            string ident = objAutor.Ident;
            string comandoSQL =
            String.Format("SELECT * FROM tblautor WHERE id='{0}', nombre='{1}' AND ident='{2}'", id, nombre);
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
            int id = objAutor.Id;
            string nombre = objAutor.Nombre;
            string ident = objAutor.Ident;
            string comandoSQL =
            String.Format("INSERT INTO tblautor VALUES ('{0}','{1}','{2}')", id, nombre,ident);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Autor consultar()
        {
            string msg = "ok";
            int id = objAutor.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tblautor WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objAutor.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objAutor.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objAutor.Ident = objDataSet.Tables[0].Rows[1][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objAutor;
        }

        public void modificar()
        {
            int id = objAutor.Id;
            string nombre = objAutor.Nombre;
            string ident = objAutor.Ident;
            string comandoSQL =
            String.Format("UPDATE tblautor SET nombre='{0}' WHERE id='{1}'", nombre, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objAutor.Id;
            string comandoSQL =
            String.Format("DELETE FROM tblautor WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Autor[] listar()
        {
            string msg = "ok";
            int i;
            Autor[] arregloAutor = null;
            string comandoSQL = String.Format("SELECT * FROM tblautor");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloAutor = new Autor[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objAutor = new Autor();
                        objAutor.Id = Int32.Parse(objDataSet.Tables[0].Rows[i][0].ToString());
                        objAutor.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();
                        objAutor.Ident = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloAutor[i] = objAutor;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloAutor;
        }
    }
}