using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto
    {
        private string Patente;
        private string Marca;
        private string Modelo;
        private string Detalles;
        private int Precio;
        private DateTime FechaEntrega;
        private DateTime FechaDevolucion;
        private bool Disponible;

        // Constructor de la clase Auto
        public Auto(string patente, string marca, string modelo, string detalles, int precio, DateTime fechaEntrega, DateTime fechaDevolucion, bool disponible)
        {
            Patente = patente;
            Marca = marca;
            Modelo = modelo;
            Detalles = detalles;
            Precio = precio;
            FechaEntrega = fechaEntrega;
            FechaDevolucion = fechaDevolucion;
            Disponible = disponible;
        }

        // Método para alquilar el auto
        public void Alquilar(DateTime fechaEntrega, DateTime fechaDevolucion)
        {
            FechaEntrega = fechaEntrega;
            FechaDevolucion = fechaDevolucion;
            Disponible = false;
        }

        // Método para liberar el auto
        public void Liberar()
        {
            this.Disponible = true;
        }

        public void Modi(string patente, string marca, string modelo, string detalles, int precio)
        {
            Patente = patente;
            Marca = marca;
            Modelo = modelo;
            Detalles = detalles;
            Precio = precio;
        }

        public string GetPatente()
        {
            return Patente;
        }

        public string GetMarca()
        {
            return Marca;
        }

        public string GetModelo()
        {
            return Modelo;
        }

        public string GetDetalles()
        {
            return Detalles;
        }

        public int GetPrecio()
        {
            return Precio;
        }

        public DateTime GetFechaEntrega()
        {
            return FechaEntrega;
        }

        public DateTime GetFechaDevolucion()
        {
            return FechaDevolucion;
        }

        public bool GetDisponible()
        {
            return Disponible;
        }

    }
}