using Oracle.ManagedDataAccess.Client;
using System;
using Dapper;
//using Dapper.Contrib;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Servidor.Datos
{
    public class ConexionOracle
    {
        private const String SOURCE = "";
        private const String USER   = "";
        private const String PASSWD = "";
        private const String STRING_CONEXION = "DATA SOURCE="+SOURCE+";USER ID="+USER+";PASSWORD="+PASSWD+";";
        private static IDbConnection con = new OracleConnection(STRING_CONEXION);
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
            return con.GetAll<List<T>>();//DAPPER
        }
        public static T Get<T>(int id)
        {
            return con.QueryFirstOrDefault<T>("");//  <----- ESTO SE TIENE QUE IR
            //return con.Get<T>(id);//DAPPER
        }
        public static T Get<T>(String rut)
        {
            String sql = "SELECT FROM USUARIO WHERE rut='"+rut+"';";
            return con.QueryFirstOrDefault<T>(sql);
        }
        public static bool Insert(dynamic objeto)
        {
            try
            {
                //con.Insert(objeto);//DAPPER
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static bool Update(dynamic objeto)
        {
            //return con.Update(objeto);//DAPPER
            return true;//                            <----- ESTO SE TIENE QUE IR
        }
        public static bool Delete(dynamic objeto)
        {
            //return con.Delete(objeto);//DAPPER
            return true;//                            <----- ESTO SE TIENE QUE IR
        }
        /*public static bool InsertMany(List<dynamic> lista)
        {
            try
            {
                con.Insert(lista);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateMany(List<dynamic> objeto)
        {
            return con.Update(objeto);
        }*/
    }
}
