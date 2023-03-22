using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto_sisevid.Models;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlSentido
    {
        Sentido objSentido;
        string baseDeDatos;

        public ControlSentido(Sentido objSentido)
        {
            this.objSentido = objSentido;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlSentido()
        {
            this.objSentido = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objSentido.Id;
            string nombre = objSentido.Nombre;
            string comandoSQL =
            String.Format("SELECT * FROM sentido WHERE id='{0}' AND nombre='{1}'", id, nombre);
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
            int id = objSentido.Id;
            string nombre = objSentido.Nombre;

            string comandoSQL =
            String.Format("INSERT INTO sentido VALUES ('{0}','{1}')", id, nombre);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Sentido consultar()
        {
            string msg = "ok";
            int id = objSentido.Id;
            string comandoSQL =
            String.Format("SELECT * FROM sentido WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objSentido.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objSentido.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objSentido;
        }
        public void modificar()
        {
            int id = objSentido.Id;
            string nombre = objSentido.Nombre;

            string comandoSQL =
            String.Format("UPDATE sentido SET nombre='{0}' WHERE id='{1}'", nombre, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objSentido.Id;
            string comandoSQL =
            String.Format("DELETE FROM sentido WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Sentido[] listar()
        {
            string msg = "ok";
            int i;
            Sentido[] arregloSentido = null;
            string comandoSQL = String.Format("SELECT * FROM sentido");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloSentido = new Sentido[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objSentido = new Sentido();
                        objSentido.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                        objSentido.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloSentido[i] = objSentido;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloSentido;
        }


    }
}