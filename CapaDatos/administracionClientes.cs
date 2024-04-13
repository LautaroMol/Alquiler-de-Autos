using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class AdministracionClientes : DatosDeConexion
    {
        public int ABMClientes(string accion, Cliente objCliente)
        {
            int resultado = -1;
            string consulta = string.Empty;

            if (accion == "Alta")
            {
                consulta = "INSERT INTO Clientes (DNI, Nombres, Apellidos, Telefono, Alquilado, Patente) " +
                           "VALUES (@DNI, @Nombres, @Apellidos, @Telefono, @Alquilado, @Patente)";
            }
            else if (accion == "Borrar")
            {
                consulta = "DELETE FROM Clientes WHERE DNI = @DNI";
            }
            else if (accion == "Modificar")
            {
                consulta = "UPDATE Clientes SET " +
                           "Nombres = @Nombres, " +
                           "Apellidos = @Apellidos, " +
                           "Telefono = @Telefono, " +
                           "Alquilado = @Alquilado, " +
                           "Patente = @Patente " +
                           "WHERE DNI = @DNI";
            }

            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@DNI", objCliente.GetDni());
                cmd.Parameters.AddWithValue("@Nombres", objCliente.GetNombres());
                cmd.Parameters.AddWithValue("@Apellidos", objCliente.GetApellidos());
                cmd.Parameters.AddWithValue("@Telefono", objCliente.GetTelefono());
                cmd.Parameters.AddWithValue("@Alquilado", objCliente.GetAlquilado());
                cmd.Parameters.AddWithValue("@Patente", objCliente.GetPatente());

                try
                {
                    conexion.Open();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    throw new Exception("Error al tratar de agregar, modificar o borrar clientes", error);
                }
                finally
                {
                    conexion.Close();
                }
            }

            return resultado; // Devuelve el resultado de la operación
        }

        public DataSet ListadoClientes(int dni)
        {
            string consulta = string.Empty;
            DataSet ds = new DataSet();

            if (dni != 0)
            {
                consulta = "SELECT * FROM Clientes WHERE DNI = @DNI";
            }
            else
            {
                consulta = "SELECT * FROM Clientes";
            }

            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                if (dni != 0)
                {
                    cmd.Parameters.AddWithValue("@DNI", dni);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    conexion.Open();
                    da.Fill(ds); // Rellena el DataSet con los datos obtenidos
                }
                catch (Exception error)
                {
                    throw new Exception("Error al listar clientes", error);
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
