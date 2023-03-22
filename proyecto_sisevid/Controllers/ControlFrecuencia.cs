using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto_sisevid.Models;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlFrecuencia
    {
        Frecuencia objFrecuencia;
        string baseDeDatos;
        public ControlFrecuencia(Frecuencia objFrecuencia)
        {
            this.objFrecuencia = objFrecuencia;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlFrecuencia()
        {
            this.objFrecuencia = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objFrecuencia.Id;
            string descripcion = objFrecuencia.Descripcion;
            string comandoSQL =
            String.Format("SELECT * FROM frecuencia WHERE id='{0}' AND descripcion='{1}'", id, descripcion);
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
            int id = objFrecuencia.Id;
            string descripcion = objFrecuencia.Descripcion;

            string comandoSQL =
            String.Format("INSERT INTO frecuencia VALUES ('{0}','{1}')", id, descripcion);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Frecuencia consultar()
        {
            string msg = "ok";
            int id = objFrecuencia.Id;
            string comandoSQL =
            String.Format("SELECT * FROM frecuencia WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objFrecuencia.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objFrecuencia.Descripcion = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objFrecuencia;
        }

        public void modificar()
        {
            int id = objFrecuencia.Id;
            string descripcion = objFrecuencia.Descripcion;

            string comandoSQL =
            String.Format("UPDATE frecuencia SET descripcion='{0}' WHERE id='{1}'", descripcion, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objFrecuencia.Id;
            string comandoSQL =
            String.Format("DELETE FROM frecuencia WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Frecuencia[] listar()
        {
            string msg = "ok";
            int i;
            Frecuencia[] arregloFrecuencia = null;
            string comandoSQL = String.Format("SELECT * FROM frecuencia");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloFrecuencia = new Frecuencia[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objFrecuencia = new Frecuencia();
                        objFrecuencia.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                        objFrecuencia.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloFrecuencia[i] = objFrecuencia;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloFrecuencia;
        }
    }
}