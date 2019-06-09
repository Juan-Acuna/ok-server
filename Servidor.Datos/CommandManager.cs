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
        public bool Insert<T>(T objeto) where T : class
        {

            String tabla = typeof(T).Name;
            FormatearComando();
            String val = "";
            SetFieldsForCommand<T>(out val, objeto);
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
        public T Get<T>(dynamic id) where T : class, new()
        {
            FormatearComando();
            String tabla = typeof(T).Name;
            String condicion ="";
            String val ="";
            if(id is String)
            {
                SetFieldsForCommand<T>(out condicion, out val, id,true);
            }
            else
            {
                SetFieldsForCommand<T>(out condicion, out val, id);
            }
            buscar = buscar.Replace("VALORES", val);
            buscar = buscar.Replace("TABLA", tabla);
            buscar = buscar.Replace("CONDICION", condicion);
            Console.WriteLine(buscar);
            try
            {
                _select = new OracleCommand(buscar, con);
                _select.CommandType = CommandType.Text;
                OracleDataReader dReader = _select.ExecuteReader();
                Object[] obj = new Object[typeof(T).GetProperties().Length];
                while (dReader.Read())
                {
                    dReader.GetValues(obj);
                }
                dReader.Close();
                if (obj[0] == null)
                {
                    return default(T);
                }
                else
                {
                    T t = new T();
                    var m = typeof(T).GetProperties();
                    int l = 0;
                    foreach (var item in m)
                    {

                        item.SetValue(t, obj[l]);
                        l++;
                    }
                    return t;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }
        public List<T> GetAll<T>() where T : class
        {
            String tabla = typeof(T).Name;
            FormatearComando();
            String val = "";
            SetFieldsForCommand(out val);
            buscar = buscar.Replace("VALORES", val);
            buscar = buscar.Replace("TABLA", tabla);
            buscar = buscar.Replace("WHERE CONDICION", "");
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
        public bool Update<T>(T objeto) where T : class
        {
            String tabla = typeof(T).Name;
            FormatearComando();
            String val = "";
            String condicion = "";
            SetFieldsForCommand<T>(out condicion,out val,objeto);
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
        public bool Delete<T>(T objeto) where T : class
        {
            String tabla = typeof(T).Name;
            var miembros = typeof(T).GetProperties();
            FormatearComando();
            String condicion = "";
            if(miembros[0].GetValue(objeto) is String)
            {
                condicion = FormatId(miembros[0].Name, miembros[0].GetValue(objeto), true);
            }
            else
            {
                condicion = FormatId(miembros[0].Name, miembros[0].GetValue(objeto));
            }
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
            insertar = "INSERT INTO TABLA VALUES(VALORES)";
            buscar = "SELECT VALORES FROM TABLA WHERE CONDICION";
            actualizar = "UPDATE TABLA SET VALORES WHERE CONDICION";
            borrar = "DELETE FROM TABLA WHERE CONDICION";

        }
        private void SetFieldsForCommand<T>(out String id, out String valores, dynamic idValue, bool idIsString = false) where T : class
        {//SELECT
            var miembros = typeof(T).GetProperties();
            Console.WriteLine(miembros.Length);
            SetFieldsForCommand(out valores);
            id = FormatId(miembros[0].Name, idValue, idIsString);
        }
        private void SetFieldsForCommand(out String valores)
        {//SELECT ALL
            valores = "*";
        }
        private void SetFieldsForCommand<T>(out String id,out String valores, T objeto, bool idIsString = false) where T : class
        {//UPDATE
            var miembros = typeof(T).GetProperties();
            SetFieldsForCommand<T>(out valores,objeto);
            var idValue = miembros[0].GetValue(objeto);
            id = FormatId(miembros[0].Name, idValue, idIsString);
        }
        private void SetFieldsForCommand<T>(out String valores, T objeto) where T : class
        {//INSERT
            var miembros = typeof(T).GetProperties();
            valores = "";
            int i = 0;
            String[] vals = new String[miembros.Length-1];
            foreach(var f in miembros)
            {
                if(f.GetValue(objeto) is String)
                {
                    vals[i] = "'"+f.GetValue(objeto).ToString()+"'";
                }
                if(f.GetValue(objeto) is int)
                {
                    vals[i] = f.GetValue(objeto).ToString();
                }
                if(f.GetValue(objeto) is bool)
                {
                    vals[i] = ((bool)f.GetValue(objeto))?"'1'":"'0'";
                }
                if(f.GetValue(objeto) is DateTime)
                {
                    vals[i] = "'" + ((DateTime)f.GetValue(objeto)).Date.ToString() + "'";
                }
                i++;
            }
            i = 0;
            //ANULAR LA ID PORQUE LA GENERA LA BDD
            foreach (var inf in miembros)
            {
                if (i > 0)
                {
                    valores += inf.Name + "="+vals[i];
                }
                i++;
            }
        }
        private String FormatId(String field, dynamic idValue,bool idIsString = false)
        {
            if (idIsString)
            {
                return field + "='" + idValue + "'";
            }
            else
            {
                return field + "=" + idValue.ToString();
            }
        }
    }
}
