using CapaDatos;
using Entidades;
using System.Data;

namespace CapaInstituto
{
    public class NegAuto
    {
        AdministracionAutos datosAuto = new AdministracionAutos();

        public int abmAutos(string accion, Auto objAuto)
        {
            return datosAuto.abmAutos(accion, objAuto);
        }

        public DataSet listadoAutos(string patente)
        {
            return datosAuto.ListadoAutos(patente);
        }
    }
}
