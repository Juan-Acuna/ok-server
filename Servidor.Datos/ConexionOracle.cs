using Oracle.ManagedDataAccess.Client;
using System;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Servidor.Datos
{
    public class ConexionOracle
    {
        private const String SOURCE = "";
        private const String USER   = "SERVIDOR_TEST_1";
        private const String PASSWD = "servidor123";
        private const String STRING_CONEXION = "DATA SOURCE="+SOURCE+";USER ID="+USER+";PASSWORD="+PASSWD+";";
        private static IDbConnection con = new OracleConnection(STRING_CONEXION);
        private static ConexionOracle _instance = new ConexionOracle();
        public ConexionOracle()
        {
            con.Open();
        }
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
            //return con.GetAll<T>().AsList();
            return new List<T>();
        }
        public static T Get<T>(int id)
        {
            //return con.Get<T>(id);
            return default(T);
        }
        public static T Get<T>(String rut)
        {
            String sql = "SELECT FROM USUARIO WHERE rut='"+rut+"';";
            return con.QueryFirstOrDefault<T>(sql);
        }
        public static bool Insert(Object objeto)
        {
            try
            {
                con.Insert(objeto);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static bool Update(Object objeto)
        {
            return con.Update(objeto);
        }
        public static bool Delete(Object objeto)
        {
            return con.Delete(objeto);
        }
    }
}
