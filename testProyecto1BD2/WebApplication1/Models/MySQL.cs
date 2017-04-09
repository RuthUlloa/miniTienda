using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;
using System.Collections;
using System.Text;

namespace WebApplication1.Models
{
    public class MySQL
    {
        MySqlConnection Conexion = new MySqlConnection("Data Source=localhost;Database=minitienda;User ID=root;Password=luna6206;");
        private bool connection_open;
        private MySqlConnection connection;

        public MySQL()
        {

        }
        public string versiconecta()
        {
            try
            {
                Conexion.Open();
                Conexion.Close();
                return "Si";
            }
            catch (Exception error)
            {
                return "NO";
            }

        }

        public int insertarOrdenDeCompraUsuario(string usuario)
        {
            Conexion.Open();
            string sql = "SELECT insertarOrdenCompra(@idUsuario)";
            MySqlCommand cmd = new MySqlCommand(sql, Conexion);
            cmd.Parameters.AddWithValue("idUsuario", usuario);
            object result = cmd.ExecuteScalar();
            Conexion.Close();
            return (int)result;
        }

        public string insertarOrdenDeCompraProducto(int producto, int orden, int cantidad)
        {
            try
            {
                Conexion.Open();
                string sql = "CALL insertarProducto(@idProducto, @idOrden, @cantidad)";
                MySqlCommand cmd = new MySqlCommand(sql, Conexion);
                cmd.Parameters.AddWithValue("idProducto", producto);
                cmd.Parameters.AddWithValue("idOrden", orden);
                cmd.Parameters.AddWithValue("cantidad", cantidad);
                cmd.ExecuteNonQuery();
                Conexion.Close();
                return "si";
            }
            catch (Exception ex)
            {
                return "no";
            }
        }

        public List<int> ordenesUsuario(string usuario)
        {
            List<int> resultado = new List<int>();
            try
            {
                Conexion.Open();
                string sql = "CALL ordenesUsuario(@usuario);";
                MySqlCommand cmd = new MySqlCommand(sql, Conexion);
                cmd.Parameters.AddWithValue("usuario", usuario);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado.Add(reader.GetInt32(0));
                    }
                }
                else
                {
                    Conexion.Close();
                    return null;
                }
                reader.Close();
                Conexion.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return null;
            }
        }


        public List<int> ordenProductos(int orden)
        {
            List<int> resultado = new List<int>();
            try
            {
                Conexion.Open();
                string sql = "CALL ordenProductos(@orden);";
                MySqlCommand cmd = new MySqlCommand(sql, Conexion);
                cmd.Parameters.AddWithValue("orden", orden);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado.Add(reader.GetInt32(0));
                    }
                }
                else
                {
                    Conexion.Close();
                    return null;
                }
                reader.Close();
                Conexion.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                return null;
            }
        }
    }
}