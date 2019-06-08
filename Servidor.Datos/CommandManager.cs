using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Servidor.Datos
{
    public class CommandManager
    {
        private OracleCommand _insert, _delete, _select, _update;
        private String insertar, borrar, buscar, actualizar;
        private ConexionOracle conexion;
        private OracleConnection con;
        public CommandManager(OracleConnection conexion)
        {
            this.con = conexion;
        }
        #region Comandos
        public bool Insert<T>(String[] parametros) where T : class
        {

            String tabla = typeof(T).Name;
            FormatearComando();
            //con.Open();
            String val = "";
            int i = 0;
            foreach (String valor in parametros)
            {
                if (valor == null || valor.Equals(""))
                {
                    if (i > 1)
                    {
                        break;
                    }
                    i++;
                    continue;
                }
                val += valor + ",";
            }
            val = val.Substring(0, val.Length - 1);
            insertar = insertar.Replace("VALORES", val);
            insertar = insertar.Replace("TABLA", tabla);
            Console.WriteLine("Val = " + insertar);
            try
            {
                _insert = new OracleCommand(insertar, con);
                _insert.CommandType = CommandType.Text;
                if (_insert.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public T Get<T>(String[] campos, String condicion) where T : class
        {
            String tabla = typeof(T).Name;
            FormatearComando();
            String val = "";
            int i = 0;
            foreach (String valor in campos)
            {
                if (valor == null || valor.Equals(""))
                {
                    if (i > 1)
                    {
                        break;
                    }
                    i++;
                    continue;
                }
                val += valor + ",";
            }
            val = val.Substring(0, val.Length - 1);
            buscar = buscar.Replace("VALORES", val);
            buscar = buscar.Replace("TABLA", tabla);
            buscar = buscar.Replace("CONDICION", condicion);
            Console.WriteLine(buscar);
            try
            {
                _select = new OracleCommand(buscar, con);
                _select.CommandType = CommandType.Text;
                OracleDataReader dReader = _select.ExecuteReader();
                Object[] obj = new Object[typeof(T).GetFields().Length-1];
                dReader.GetValues(obj);
                dReader.Close();
                if (obj[0] == null && obj[i] == null)
                {
                    return default(T);
                }
                else
                {
                    return obj as T;
                }
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
        public List<T> GetAll<T>(String[] campos, String condicion = "ALL") where T : class
        {
            String tabla = typeof(T).Name;
            FormatearComando();
            String val = "";
            int i = 0;
            foreach (String valor in campos)
            {
                if (valor == null || valor.Equals(""))
                {
                    if (i > 1)
                    {
                        break;
                    }
                    i++;
                    continue;
                }
                val += valor + ",";
            }
            val = val.Substring(0, val.Length - 1);
            buscar = buscar.Replace("VALORES", val);
            buscar = buscar.Replace("TABLA", tabla);
            if (condicion.Equals("ALL"))
            {
                buscar = buscar.Replace("WHERE CONDICION", "");
            }
            else
            {
                buscar = buscar.Replace("CONDICION", condicion);
            }
            Console.WriteLine(buscar);
            try
            {
                _select = new OracleCommand(buscar, con);
                _select.CommandType = CommandType.Text;
                OracleDataReader dReader = _select.ExecuteReader();
                List<T> lista = new List<T>();
                Object[] obj;
                while (dReader.Read())
                {
                    obj = new Object[typeof(T).GetFields().Length];
                    dReader.GetValues(obj);
                    lista.Add(obj as T);
                }
                dReader.Close();
                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool Update<T>(String[] campos, String condicion)
        {
            String tabla = typeof(T).Name;
            FormatearComando();
            String val = "";
            int i = 0;
            foreach (String valor in campos)
            {
                if (valor == null || valor.Equals(""))
                {
                    if (i > 1)
                    {
                        break;
                    }
                    i++;
                    continue;
                }
                val += valor + ",";
            }
            val = val.Substring(0, val.Length - 1);
            actualizar = actualizar.Replace("VALORES", val);
            actualizar = actualizar.Replace("TABLA", tabla);
            actualizar = actualizar.Replace("CONDICION", condicion);
            Console.WriteLine(actualizar);
            try
            {
                _update = new OracleCommand(actualizar, con);
                _update.CommandType = CommandType.Text;
                if (_update.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }

        }
        public bool Borrar<T>(String condicion)
        {
            String tabla = typeof(T).Name;
            FormatearComando();
            borrar = borrar.Replace("TABLA", tabla);
            borrar = borrar.Replace("CONDICION", condicion);
            Console.WriteLine(borrar);
            try
            {
                _delete = new OracleCommand(borrar, con);
                _delete.CommandType = CommandType.Text;
                if (_delete.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }
        #endregion
        private void FormatearComando()
        {
            insertar = "INSERT INTO TABLA VALUES(VALORES);";
            buscar = "SELECT VALORES FROM TABLA WHERE CONDICION;";
            actualizar = "UPDATE TABLA SET VALORES WHERE CONDICION;";
            borrar = "DELETE FROM TABLA WHERE CONDICION;";

        }
    }
}
