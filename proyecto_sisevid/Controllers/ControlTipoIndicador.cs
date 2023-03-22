using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto_sisevid.Models;
using System.Data;

namespace proyecto_sisevid.Controllers
{
    public class ControlTipoIndicador
    {
        TipoIndicador objTipoIndicador;
        string baseDeDatos;

        public ControlTipoIndicador(TipoIndicador objTipoIndicador) 
        {
            this.objTipoIndicador = objTipoIndicador;    
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlTipoIndicador()
        {
            this.objTipoIndicador = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }

        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objTipoIndicador.Id;
            string nombre = objTipoIndicador.Nombre;
            string comandoSQL =
            String.Format("SELECT * FROM tipoindicador WHERE id='{0}' AND nombre='{1}'", id, nombre);
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
            int id = objTipoIndicador.Id;
            string nombre = objTipoIndicador.Nombre;

            string comandoSQL =
            String.Format("INSERT INTO tipoindicador VALUES ('{0}','{1}')", id, nombre);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public TipoIndicador consultar()
        {
            string msg = "ok";
            int id = objTipoIndicador.Id;
            string comandoSQL =
            String.Format("SELECT * FROM tipoindicador WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objTipoIndicador.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objTipoIndicador.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objTipoIndicador;

        }

        public void modificar()
        {
            int id = objTipoIndicador.Id;
            string nombre = objTipoIndicador.Nombre;

            string comandoSQL =
            String.Format("UPDATE tipoindicador SET nombre='{0}' WHERE id='{1}'", nombre, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objTipoIndicador.Id;
            string comandoSQL =
            String.Format("DELETE FROM tipoindicador WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public TipoIndicador[] listar()
        {
            string msg = "ok";
            int i;
            TipoIndicador[] arregloTipoIndicador = null;
            string comandoSQL = String.Format("SELECT * FROM tipoindicador");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloTipoIndicador = new TipoIndicador[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objTipoIndicador = new TipoIndicador();
                        objTipoIndicador.Id = Int32.Parse(objDataSet.Tables[0].Rows[i][0].ToString());
                        objTipoIndicador.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloTipoIndicador[i] = objTipoIndicador;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloTipoIndicador;
        }
    }
}