using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlResponsable
    {
        Responsable objResponsable;
        string baseDeDatos;

        public ControlResponsable(Responsable objResponsable)
        {
            this.objResponsable = objResponsable;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public ControlResponsable()
        {
            this.objResponsable = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public bool validarIngreso()
        {
            string msg = "ok";
            bool validar = false;
            int cedula = objResponsable.Cedula;
            string nombre = objResponsable.Nombre;
            string email = objResponsable.Email;
            string comandoSQL =
            String.Format("SELECT * FROM responsable WHERE cedula='{0}' , nombre='{1}' AND email='{2}'", cedula, nombre,email);
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
            int cedula = objResponsable.Cedula;
            string nombre = objResponsable.Nombre;
            string email = objResponsable.Email;
            string comandoSQL =
            String.Format("INSERT INTO responsable VALUES ('{0}','{1}','{2}')", cedula, nombre,email);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public Responsable consultar()
        {
            string msg = "ok";
            int cedula = objResponsable.Cedula;
            string comandoSQL =
            String.Format("SELECT * FROM responsable WHERE cedula='{0}'", cedula);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    objResponsable.Cedula = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                    objResponsable.Nombre = objDataSet.Tables[0].Rows[0][1].ToString();
                    objResponsable.Email = objDataSet.Tables[0].Rows[1][1].ToString();
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return objResponsable;
        }
        public void modificar()
        {
            int cedula = objResponsable.Cedula;
            string nombre = objResponsable.Nombre;
            string email = objResponsable.Email;
            string comandoSQL =
            String.Format("UPDATE responsable SET nombre='{0}' WHERE cedula='{1}'", nombre, cedula);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public void borrar()
        {
            int cedula = objResponsable.Cedula;
            string comandoSQL =
            String.Format("DELETE FROM responsable WHERE cedula='{0}'", cedula);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

        public Responsable[] listar()
        {
            string msg = "ok";
            int i;
            Responsable[] arregloResponsable = null;
            string comandoSQL = String.Format("SELECT * FROM responsable");
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    arregloResponsable = new Responsable[objDataSet.Tables[0].Rows.Count];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        objResponsable = new Responsable();
                        objResponsable.Cedula = Int32.Parse(objDataSet.Tables[0].Rows[0][0].ToString());
                        objResponsable.Nombre = objDataSet.Tables[0].Rows[i][1].ToString();
                        objResponsable.Email  = objDataSet.Tables[0].Rows[i][2].ToString();

                        arregloResponsable[i] = objResponsable;
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objException)
            {
                msg = objException.Message;
            }
            return arregloResponsable;
        }

    }
}