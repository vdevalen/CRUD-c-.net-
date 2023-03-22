using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlTipoEvidencia
    {
        TipoEvidencia objTipoEvidencia;
        string baseDeDatos;

        public ControlTipoEvidencia(TipoEvidencia objTipoEvidencia)
        {
            this.objTipoEvidencia = objTipoEvidencia;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlTipoEvidencia()
        {
            this.objTipoEvidencia = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objTipoEvidencia.Id;
            string nombre = objTipoEvidencia.Nombre;
            string comandoSQL =
            String.Format("SELECT * FROM tbltipoevidencia WHERE id='{0}' AND nombre='{1}'", id, nombre);
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
            int id = objTipoEvidencia.Id;
            string nombre = objTipoEvidencia.Nombre;
            string comandoSQL =
            String.Format("INSERT INTO tbltipoevidencia VALUES ('{0}','{1}')", id, nombre);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public TipoEvidencia consultar()
        {
            string msg = "ok";
            int id = objTipoEvidencia.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tbltipoevidencia WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objTipoEvidencia.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objTipoEvidencia.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objTipoEvidencia;
        }
        public void modificar()
        {
            int id = objTipoEvidencia.Id;
            string nombre = objTipoEvidencia.Nombre;

            string comandoSQL =
            String.Format("UPDATE tbltipoevidencia SET nombre='{0}' WHERE id='{1}'", nombre, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objTipoEvidencia.Id;
            string comandoSQL =
            String.Format("DELETE FROM tbltipoevidencia WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public TipoEvidencia[] listar()
        {
            string msg = "ok";
            int i;
            TipoEvidencia[] arregloTipoEvidencia = null;
            string comandoSQL = String.Format("SELECT * FROM tbltipoevidencia");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloTipoEvidencia = new TipoEvidencia[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objTipoEvidencia = new TipoEvidencia();
                        objTipoEvidencia.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                        objTipoEvidencia.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloTipoEvidencia[i] = objTipoEvidencia;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloTipoEvidencia;
        }

    }
}