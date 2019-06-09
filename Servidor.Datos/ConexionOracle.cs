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
        protected class Conexiones
        {
            private const String SOURCE     = "LOCALHOST:1521";
            private static String USER      = "servidor_test_";
            private static String PASSWD    = "servidor123";
            public static OracleConnection OkCasa       = new OracleConnection(StringConexion("ok"));
            public static OracleConnection BancoEstado  = new OracleConnection(StringConexion("be"));
            public static OracleConnection Transbank    = new OracleConnection(StringConexion("tb"));
            private static String StringConexion(String finalUser)
            {
                return "DATA SOURCE=" + SOURCE + ";USER ID=" + USER + finalUser + ";PASSWORD=" + PASSWD + ";";
            }
        }
        private static ConexionOracle _instance = new ConexionOracle();
        private static OracleConnection con;
        private ConexionOracle()
        {
            Conexiones.OkCasa.Open();
            Conexiones.BancoEstado.Open();
            Conexiones.Transbank.Open();
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
        public List<T> GetAll<T>(DataBaseConUser dbcu) where T : class, new()
        {
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    con = Conexiones.OkCasa;
                    break;
                case DataBaseConUser.BancoEstado:
                    con = Conexiones.BancoEstado;
                    break;
                case DataBaseConUser.Transbank:
                    con = Conexiones.Transbank;
                    break;
            }
            CommandManager cmd = new CommandManager(con);
            return cmd.GetAll<T>();
        }
        public T Get<T>(dynamic id, DataBaseConUser dbcu) where T : class, new()
        {
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    con = Conexiones.OkCasa;
                    break;
                case DataBaseConUser.BancoEstado:
                    con = Conexiones.BancoEstado;
                    break;
                case DataBaseConUser.Transbank:
                    con = Conexiones.Transbank;
                    break;
            }
            CommandManager cmd = new CommandManager(con);
            return cmd.Get<T>(id);
        }
        public bool Insert<T>(T objeto, DataBaseConUser dbcu,bool autoId = true) where T : class, new()
        {
            try
            {
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    con = Conexiones.OkCasa;
                    break;
                case DataBaseConUser.BancoEstado:
                    con = Conexiones.BancoEstado;
                    break;
                case DataBaseConUser.Transbank:
                    con = Conexiones.Transbank;
                    break;
            }
            CommandManager cmd = new CommandManager(con);
            return cmd.Insert(objeto,autoId);
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
                    con = Conexiones.OkCasa;
                    break;
                case DataBaseConUser.BancoEstado:
                    con = Conexiones.BancoEstado;
                    break;
                case DataBaseConUser.Transbank:
                    con = Conexiones.Transbank;
                    break;
            }
            CommandManager cmd = new CommandManager(con);
            return cmd.Update(objeto);
        }
        public bool Delete<T>(T objeto, DataBaseConUser dbcu) where T : class, new()
        {
            switch (dbcu)
            {
                case DataBaseConUser.OkCasa:
                    con = Conexiones.OkCasa;
                    break;
                case DataBaseConUser.BancoEstado:
                    con = Conexiones.BancoEstado;
                    break;
                case DataBaseConUser.Transbank:
                    con = Conexiones.Transbank;
                    break;
            }
            CommandManager cmd = new CommandManager(con);
            return cmd.Delete(objeto);
        }
    }
    public enum DataBaseConUser
    {
        OkCasa,
        BancoEstado,
        Transbank
    }
}
