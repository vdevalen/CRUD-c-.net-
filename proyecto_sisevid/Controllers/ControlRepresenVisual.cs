using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto_sisevid.Models;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlRepresenVisual
    {
        RepresenVisual objRepresenVisual;
        string baseDeDatos;

        public ControlRepresenVisual(RepresenVisual objRepresenVisual)
        {
            this.objRepresenVisual = objRepresenVisual;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlRepresenVisual()
        {
            this.objRepresenVisual = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objRepresenVisual.Id;
            string nombre = objRepresenVisual.Nombre;
            string comandoSQL =
            String.Format("SELECT * FROM represenvisual WHERE id='{0}' AND nombre='{1}'", id, nombre);
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
            int id = objRepresenVisual.Id;
            string nombre = objRepresenVisual.Nombre;

            string comandoSQL =
            String.Format("INSERT INTO represenvisual VALUES ('{0}','{1}')", id, nombre);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public RepresenVisual consultar()
        {
            string msg = "ok";
            int id = objRepresenVisual.Id;
            string comandoSQL =
            String.Format("SELECT * FROM represenvisual WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objRepresenVisual.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objRepresenVisual.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objRepresenVisual;
        }
        public void modificar()
        {
            int id = objRepresenVisual.Id;
            string nombre = objRepresenVisual.Nombre;

            string comandoSQL =
            String.Format("UPDATE represenvisual SET nombre='{0}' WHERE id='{1}'", nombre, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objRepresenVisual.Id;
            string comandoSQL =
            String.Format("DELETE FROM represenvisual WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public RepresenVisual[] listar()
        {
            string msg = "ok";
            int i;
            RepresenVisual[] arregloRepresenVisual = null;
            string comandoSQL = String.Format("SELECT * FROM represenvisual");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloRepresenVisual = new RepresenVisual[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objRepresenVisual = new RepresenVisual();
                        objRepresenVisual.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                        objRepresenVisual.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloRepresenVisual[i] = objRepresenVisual;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloRepresenVisual;
        }


    }
}