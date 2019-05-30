using Oracle.ManagedDataAccess.Client;
using System;
using Dapper;
using System.Collections.Generic;
using System.Text;

namespace Servidor.Datos
{
    class ConexionOracle
    {
        private const String SOURCE = "";
        private const String USER   = "";
        private const String PASSWD = "";
        private const String STRING_CONEXION = "DATA SOURCE="+SOURCE+";USER ID="+USER+";PASSWORD="+PASSWD+";";
        private static OracleConnection con = new OracleConnection(STRING_CONEXION);
        private static ConexionOracle _instance = new ConexionOracle();
        public static ConexionOracle Conexion
        {
            get {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return _instance = new ConexionOracle();
                }
            }
        }
        public static List<T> GetAll<T>()
        {
            return con.GetAll<List<T>>();
        }
        public static T Get<T>(int id)
        {
            return con.Get<T>(id);
        }
        public static T Get<T>(String rut)
        {
            String sql = "SELECT FROM USUARIO WHERE rut='"+rut+"';";
            return con.QueryFirstOrDefault<T>(sql);
        }
    }
}
