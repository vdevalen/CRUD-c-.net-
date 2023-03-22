using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using proyecto_sisevid.Models;

namespace proyecto_sisevid.Controllers
{
    public class ControlUnidadDeMedicion
    {
        UnidadDeMedicion objUnidadDeMedicion;
        string baseDeDatos;

        public ControlUnidadDeMedicion(UnidadDeMedicion objUnidadDeMedicion)
        {
            this.objUnidadDeMedicion = objUnidadDeMedicion;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlUnidadDeMedicion()
        {
            this.objUnidadDeMedicion = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int id = objUnidadDeMedicion.Id;
            string descripcion = objUnidadDeMedicion.Descripcion;
            string comandoSQL =
            String.Format("SELECT * FROM unidad_de_medicion WHERE id='{0}' AND descripcion='{1}'", id, descripcion);
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
            int id = objUnidadDeMedicion.Id;
            string descripcion = objUnidadDeMedicion.Descripcion;

            string comandoSQL =
            String.Format("INSERT INTO unidad_de_medicion VALUES ('{0}','{1}')", id, descripcion);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public UnidadDeMedicion consultar()
        {
            string msg = "ok";
            int id = objUnidadDeMedicion.Id;
            string comandoSQL =
            String.Format("SELECT * FROM unidad_de_medicion WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objUnidadDeMedicion.Id = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objUnidadDeMedicion.Descripcion = objDataSet.Tables[0].Rows[0][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objUnidadDeMedicion;
        }
        public void modificar()
        {
            int id = objUnidadDeMedicion.Id;
            string descripcion = objUnidadDeMedicion.Descripcion;

            string comandoSQL =
            String.Format("UPDATE unidad_de_medicion SET descripcion='{0}' WHERE id='{1}'", descripcion, id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int id = objUnidadDeMedicion.Id;
            string comandoSQL =
            String.Format("DELETE FROM unidad_de_medicion WHERE id='{0}'", id);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public UnidadDeMedicion[] listar() {
            string msg = "ok";
            int i;
            UnidadDeMedicion[] arregloUnidadDeMedicion = null; 
            string comandoSQL = String.Format("SELECT * FROM unidad_de_medicion");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloUnidadDeMedicion = new UnidadDeMedicion[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objUnidadDeMedicion = new UnidadDeMedicion();
                        objUnidadDeMedicion.Id = Int32.Parse(objDataSet.Tables[0].Rows[i][0].ToString());
                        objUnidadDeMedicion.Descripcion = objDataSet.Tables[0].Rows[i][1].ToString();

                        arregloUnidadDeMedicion[i] = objUnidadDeMedicion;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloUnidadDeMedicion;
        }
    }

}

