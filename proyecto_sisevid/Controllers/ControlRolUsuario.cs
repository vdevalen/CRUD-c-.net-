//using MiBiblioteca;
using proyecto_sisevid.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace proyecto_sisevid.Controllers
{
    public class ControlRolUsuario
    {
        RolUsuario objRolUsuario;
        string baseDeDatos;

        public ControlRolUsuario(RolUsuario objRolUsuario)
        {
            this.objRolUsuario = objRolUsuario;
            baseDeDatos = "BD_SISEVID_015224.mdf";

        }
        public ControlRolUsuario()
        {
            this.objRolUsuario = null;
            baseDeDatos = "BD_SISEVID_015224.mdf";
        }
        public void guardar()
        {
            string fkNomU = objRolUsuario.FkNomUsuario;
            int fkIdR = objRolUsuario.FkIdRol;

            string comandoSQL =
            String.Format("INSERT INTO tblRol_Usuario VALUES ('{0}',{1})", fkNomU, fkIdR);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }
        public string[,] consultarRoles_por_NomUsuario()
        {
            string msg = "ok";
            int i;
            string[,] matRolUsuario = null;
            string nomUsu = objRolUsuario.FkNomUsuario;
            string comandoSQL =
            String.Format("SELECT tblrol.id,tblrol.nombre " +
                        "FROM tblrol INNER JOIN tblrol_usuario ON tblrol.id=tblrol_usuario.fkIdRol" +
                        " WHERE tblrol_usuario.fkNomUsuario='{0}'", nomUsu);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            DataSet objDataSet = objControlConexion.ejecutarConsultasSql(comandoSQL);
            try
            {
                if (objDataSet.Tables[0].Rows.Count > 0)
                {
                    i = 0;
                    matRolUsuario = new string[objDataSet.Tables[0].Rows.Count,2];
                    while (i < objDataSet.Tables[0].Rows.Count)
                    {
                        matRolUsuario[i,0] = objDataSet.Tables[0].Rows[i][0].ToString();
                        matRolUsuario[i,1] = objDataSet.Tables[0].Rows[i][1].ToString();
                        i++;
                    }
                    objControlConexion.cerrarBD();
                }
            }
            catch (Exception objExcetion)
            {
                msg = objExcetion.Message;
            }
            return matRolUsuario;
        }
        public void borrarDelNomUsuario()
        {
            string fkNomU = objRolUsuario.FkNomUsuario;
            string comandoSQL =
            String.Format("DELETE FROM tblrol_usuario WHERE fkNomUsuario='{0}'", fkNomU);
            ControlConexion objControlConexion = new ControlConexion(baseDeDatos);
            objControlConexion.abrirBD();
            objControlConexion.ejecutarComandoSQL(comandoSQL);
            objControlConexion.cerrarBD();
        }

    }
}