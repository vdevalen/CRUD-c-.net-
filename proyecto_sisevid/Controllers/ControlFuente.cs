using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlFuente
    {
        Fuente objFuente;
        string baseDeDatos;

        public ControlFuente(Fuente objFuente)
        {
            this.objFuente = objFuente;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlFuente()
        {
            this.objFuente = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }

        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objFuente.Id;
            string nombre = objFuente.Nombre;
            string comandoSQL =
            String.Format("SELECT * FROM fuente WHERE id='{0}' AND nombre='{1}'", id, nombre);
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
            int id = objFuente.Id;
            string nombre = objFuente.Nombre;

            string comandoSQL =
            String.Format("INSERT INTO fuente VALUES ('{0}','{1}')", id, nombre);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Fuente consultar()
        {
            string msg = "ok";
            int id = objFuente.Id;
            string comandoSQL =
            String.Format("SELECT * FROM fuente WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objFuente.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objFuente.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objFuente;
        }
        public void modificar()
        {
            int id = objFuente.Id;
            string nombre = objFuente.Nombre;

            string comandoSQL =
            String.Format("UPDATE fuente SET nombre='{0}' WHERE id='{1}'", nombre, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objFuente.Id;
            string comandoSQL =
            String.Format("DELETE FROM fuente WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Fuente[] listar()
        {
            string msg = "ok";
            int i;
            Fuente[] arregloFuente = null;
            string comandoSQL = String.Format("SELECT * FROM fuente");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloFuente = new Fuente[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objFuente = new Fuente();
                        objFuente.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                        objFuente.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloFuente[i] = objFuente;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloFuente;
        }

    }
}