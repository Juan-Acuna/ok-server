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
        private static String USER   = "SERVIDOR_TEST_";
        private static String PASSWD = "servidor123";
        private static IDbConnection con;
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
        public List<T> GetAll<T>(DataBaseConUser dbcu) where T : class
        {
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    USER += "ok";
                    break;
                case DataBaseConUser.BancoEstado:
                    USER += "be";
                    break;
                case DataBaseConUser.Transbank:
                    USER += "tb";
                    break;
            }
            using (con = new OracleConnection(StringConexion()))
            {
                return con.GetAll<T>().AsList();
            }
        }
        public T Get<T>(int id, DataBaseConUser dbcu) where T : class
        {
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    USER += "ok";
                    break;
                case DataBaseConUser.BancoEstado:
                    USER += "be";
                    break;
                case DataBaseConUser.Transbank:
                    USER += "tb";
                    break;
            }
            using (con = new OracleConnection(StringConexion()))
            {
                return con.Get<T>(id);
            }
        }
        public T Get<T>(String rut, DataBaseConUser dbcu) where T : class
        {   //typeof(T).Name devuelve el nombre de la clase.
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    USER += "ok";
                    break;
                case DataBaseConUser.BancoEstado:
                    USER += "be";
                    break;
                case DataBaseConUser.Transbank:
                    USER += "tb";
                    break;
            }
            using (con = new OracleConnection(StringConexion()))
            {
                return con.Get<T>(rut);
            }
        }
        public bool Insert(Object objeto, DataBaseConUser dbcu)
        {
            try
            {
                switch (dbcu)
                {
                    case DataBaseConUser.OkCasa:
                        USER += "ok";
                        break;
                    case DataBaseConUser.BancoEstado:
                        USER += "be";
                        break;
                    case DataBaseConUser.Transbank:
                        USER += "tb";
                        break;
                }
                using (con = new OracleConnection(StringConexion()))
                {
                    con.Insert(objeto);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Update(Object objeto, DataBaseConUser dbcu)
        {
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    USER += "ok";
                    break;
                case DataBaseConUser.BancoEstado:
                    USER += "be";
                    break;
                case DataBaseConUser.Transbank:
                    USER += "tb";
                    break;
            }
            using (con = new OracleConnection(StringConexion()))
            {
                return con.Update(objeto);
            }
            
        }
        public bool Delete(Object objeto, DataBaseConUser dbcu)
        {
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    USER += "ok";
                    break;
                case DataBaseConUser.BancoEstado:
                    USER += "be";
                    break;
                case DataBaseConUser.Transbank:
                    USER += "tb";
                    break;
            }
            using (con = new OracleConnection(StringConexion()))
            {
                return con.Delete(objeto);
            }
            
        }
        private String StringConexion()
        {
            return "DATA SOURCE=" + SOURCE + ";USER ID=" + USER + ";PASSWORD=" + PASSWD + ";";
    }
    }
    public enum DataBaseConUser
    {
        OkCasa,
        BancoEstado,
        Transbank
    }
}
