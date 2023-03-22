using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_sisevid.Controllers
{
    public class ControlConexion
    {
        String cadenaConexion;
        //System.Data.SqlClient.SqlConnection objSqlConnection;
        SqlConnection objSqlConnection;

        public ControlConexion()
        {
            cadenaConexion = null;
            objSqlConnection = null;
        }

        public ControlConexion(String baseDeDatos)
        {
            this.cadenaConexion = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\"+ baseDeDatos + ";Integrated Security = True"; ;
            
            objSqlConnection = new SqlConnection(cadenaConexion);
        }

        public String abrirBD()
        {
            String msg = "ok";
            try
            {
                objSqlConnection = new SqlConnection(cadenaConexion);
                objSqlConnection.Open();
            }
            catch (Exception Ex)
            {
                msg = Ex.Message;
            }
            return msg;
        }

        public String cerrarBD()
        {
            String msg = "ok";
            try
            {
                objSqlConnection.Close();
            }
            catch (Exception Ex)
            {
                msg = Ex.Message;
            }
            return msg;
        }

        public String ejecutarComandoSQL(String comandoSql)
        {
            String msg = "ok";
            try
            {
                SqlCommand sqlComando = new SqlCommand(comandoSql, objSqlConnection);
                sqlComando.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                msg = Ex.Message;
            }
            return msg;
        }

        public DataSet ejecutarConsultasSql(String comandoSql)
        {
            String msg = "ok";
            DataSet objDataSet = new DataSet();

            try
            {
                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(comandoSql, objSqlConnection);
                sqlDataAdap.Fill(objDataSet);
            }
            catch (Exception Exc)
            {
                msg = Exc.Message;
            }
            return objDataSet;
        }
    }
}
