using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlEstado
    {
        Estado objEstado;
        string baseDeDatos;

        public ControlEstado(Estado objEstado)
        {
            this.objEstado = objEstado;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlEstado()
        {
            this.objEstado = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objEstado.Id;
            string nombre = objEstado.Nombre;
            string comandoSQL =
            String.Format("SELECT * FROM tblestado WHERE id='{0}' AND nombre='{1}'", id, nombre);
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
            int id = objEstado.Id;
            string nombre = objEstado.Nombre;

            string comandoSQL =
            String.Format("INSERT INTO tblestado VALUES ('{0}','{1}')", id, nombre);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Estado consultar()
        {
            string msg = "ok";
            int id = objEstado.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tblestado WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objEstado.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objEstado.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objEstado;
        }
        public void modificar()
        {
            int id = objEstado.Id;
            string nombre = objEstado.Nombre;

            string comandoSQL =
            String.Format("UPDATE tblestado SET nombre='{0}' WHERE id='{1}'", nombre, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objEstado.Id;
            string comandoSQL =
            String.Format("DELETE FROM tblestado WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Estado[] listar()
        {
            string msg = "ok";
            int i;
            Estado[] arregloEstado = null;
            string comandoSQL = String.Format("SELECT * FROM tblestado");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloEstado = new Estado[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objEstado = new Estado();
                        objEstado.Id = Int32.Parse(objDataSet.Tables[0].Rows[i][0].ToString());
                        objEstado.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloEstado[i] = objEstado;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloEstado;
        }

    }
}