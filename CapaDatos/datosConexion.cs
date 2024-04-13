using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosDeConexion
    {
        protected SqlConnection conexion;
        public string CadenadeConexion = $"Data Source=DESKTOP-P7SSU03;Initial Catalog=AlquilerAutos;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";

        public DatosDeConexion()
        {
            conexion = new SqlConnection(CadenadeConexion);
        }

        public void AbrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Broken || conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception error)
            {
                throw new Exception("Error al tratar de abrir la conexión", error);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception error)
            {
                throw new Exception("Error al tratar de cerrar la conexión", error);
            }
        }
    }
}
