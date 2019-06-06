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
        private const String SOURCE = "LOCALHOST:1521";
        private const String USER   = "SERVIDOR_TEST_1";
        private const String PASSWD = "servidor123";
        private const String STRING_CONEXION = "DATA SOURCE="+SOURCE+";USER ID="+USER+";PASSWORD="+PASSWD+ ";";
        private static IDbConnection con = new OracleConnection(STRING_CONEXION);
        private static ConexionOracle _instance = new ConexionOracle();
        public ConexionOracle()
        {
            try
            {
                con.Open();
                Console.WriteLine("Conexion abierta...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
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
        public List<T> GetAll<T>() where T : class
        {
            return con.GetAll<T>().AsList();
        }
        public T Get<T>(int id) where T : class
        {
            return con.Get<T>(id);
        }
        public T Get<T>(String rut)
        {   //typeof(T).Name devuelve el nombre de la clase.
            String sql = $"SELECT * FROM USUARIO WHERE rut='{rut}'";
            try
            {
                return con.QueryFirstOrDefault<T>(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }
        public bool Insert(Object objeto)
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
        public bool Update(Object objeto)
        {
            return con.Update(objeto);
        }
        public bool Delete(Object objeto)
        {
            return con.Delete(objeto);
        }
    }
}
