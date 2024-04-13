using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private int dni;
        private string nombres;
        private string apellidos;
        private int telefono;
        private bool alquilado;
        private string patente;

        public Cliente(int dni, string nombres, string apellidos, int telefono)
        {
            this.dni = dni;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefono;
            alquilado = false;
            this.patente = "sin asignar";
        }
        public Cliente(int dni, string nombres, string apellidos, int telefono, string patente,bool alquilado)
        {
            this.dni = dni;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.alquilado = alquilado;
            this.patente = "sin asignar";
        }

        public void Modi(string Nombre,string Apellido,int Telefono)
        {
            nombres = Nombre;
            apellidos = Apellido;
            telefono = Telefono;
        }
        public void reserva(string patente)
        {
            this.patente = patente;
            alquilado = true;
        }
        public void Liberar()
        {
            patente = "Sin asignar";
            alquilado = false;
        }
        public int GetDni()
        {
            return dni;
        }

        public string GetNombres()
        {
            return nombres;
        }

        public string GetApellidos()
        {
            return apellidos;
        }

        public int GetTelefono()
        {
            return telefono;
        }

        public bool GetAlquilado()
        {
            return alquilado;
        }

        public string GetPatente()
        {
            return patente;
        }

    }
}
