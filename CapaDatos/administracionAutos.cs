using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class AdministracionAutos : DatosDeConexion
    {
        public int abmAutos(string accion, Auto objAuto)
        {
            int resultado = -1;
            string consulta = string.Empty;

            if (accion == "Alta")
            {
                consulta = "INSERT INTO Autos (Patente, Marca, Modelo, Detalles, Precio, FechaEntrega, FechaDevolucion, Disponible) " +
                           "VALUES (@Patente, @Marca, @Modelo, @Detalles, @Precio, @FechaEntrega, @FechaDevolucion, @Disponible)";
            }
            else if (accion == "Borrar")
            {
                consulta = "DELETE FROM Autos WHERE Patente = @Patente";
            }
            else if (accion == "Modificar")
            {
                consulta = "UPDATE Autos SET " +
                           "Marca = @Marca, " +
                           "Modelo = @Modelo, " +
                           "Detalles = @Detalles, " +
                           "Precio = @Precio, " +
                           "FechaEntrega = @FechaEntrega, " +
                           "FechaDevolucion = @FechaDevolucion, " +
                           "Disponible = @Disponible " +
                           "WHERE Patente = @Patente";
            }


            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@Patente", objAuto.GetPatente());
                cmd.Parameters.AddWithValue("@Marca", objAuto.GetMarca());
                cmd.Parameters.AddWithValue("@Modelo", objAuto.GetModelo());
                cmd.Parameters.AddWithValue("@Detalles", objAuto.GetDetalles());
                cmd.Parameters.AddWithValue("@Precio", objAuto.GetPrecio());
                cmd.Parameters.AddWithValue("@FechaEntrega", objAuto.GetFechaEntrega());
                cmd.Parameters.AddWithValue("@FechaDevolucion", objAuto.GetFechaDevolucion());
                cmd.Parameters.AddWithValue("@Disponible", objAuto.GetDisponible());

                try
                {
                    conexion.Open();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    throw new Exception("Error al tratar de agregar, modificar o borrar autos", error);
                }
                finally
                {
                    conexion.Close();
                }
            }

            return resultado; // Devuelve el resultado de la operación
        }

        public DataSet ListadoAutos(string patente)
        {
            string consulta = string.Empty;
            DataSet ds = new DataSet();

            if (patente != "todos")
            {
                consulta = "SELECT * FROM Autos WHERE Patente = @Patente";
            }
            else
            {
                consulta = "select * from Autos;";
            }

            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                if (patente != "todos")
                {
                    cmd.Parameters.AddWithValue("@Patente", patente);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conexion.Open();
                    da.Fill(ds); // Rellena el DataSet con los datos obtenidos
                }
                catch (Exception error)
                {
                    throw new Exception("Error al listar autos", error);
                }
                finally
                {
                    conexion.Close();
                }
            }

            return ds; // Devuelve el conjunto de datos
        }
    }
}
