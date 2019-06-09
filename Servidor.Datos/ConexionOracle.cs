using Oracle.ManagedDataAccess.Client;
using System;
//using Dapper;
//using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;

namespace Servidor.Datos
{
    public class ConexionOracle
    {
        private const String SOURCE = "LOCALHOST:1521";
        private static String USER   = "SERVIDOR_TEST_";
        private static String PASSWD = "servidor123";
        private static OracleConnection con;
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
        public List<T> GetAll<T>(DataBaseConUser dbcu) where T : class, new()
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
                CommandManager cmd = new CommandManager(con);
                con.Open();
                return cmd.GetAll<T>();
            }
        }
        public T Get<T>(dynamic id, DataBaseConUser dbcu) where T : class, new()
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
                CommandManager cmd = new CommandManager(con);
                con.Open();
                return cmd.Get<T>(id);
            }
        }
        public bool Insert<T>(T objeto, DataBaseConUser dbcu) where T : class, new()
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
                    CommandManager cmd = new CommandManager(con);
                    con.Open();
                    return cmd.Insert(objeto);
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool Update<T>(T objeto, DataBaseConUser dbcu) where T : class, new()
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
                CommandManager cmd = new CommandManager(con);
                con.Open();
                return cmd.Update(objeto);
            }
            
        }
        public bool Delete<T>(T objeto, DataBaseConUser dbcu) where T : class, new()
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
                CommandManager cmd = new CommandManager(con);
                con.Open();
                return cmd.Delete(objeto);
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
