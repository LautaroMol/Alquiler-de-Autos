using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegCliente
    {
        AdministracionClientes datosCliente = new AdministracionClientes();

        public int abmCliente(string accion, Cliente objCliente)
        {
            return datosCliente.ABMClientes(accion, objCliente);
        }

        public DataSet listadoCliente(int dni)
        {
            return datosCliente.ListadoClientes(dni);
        }
    }
}
