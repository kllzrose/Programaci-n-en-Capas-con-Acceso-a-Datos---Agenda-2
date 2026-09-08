using System;
using System.Collections.Generic;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class Persona
    {
        public string Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public string Calle { get; set; }
        public int Depto { get; set; }
        public int Piso { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string CuilCuit { get; set; }
        public DateTime FechaAlta { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Barrio { get; set; }
        public string TelefonoAlternativo { get; set; }
        public string RedSocial { get; set; }
        public string Profesion { get; set; }
        public string EmpresaTrabajo { get; set; }
        public string NivelEstudios { get; set; }
        public bool Estado { get; set; } 
        public string MetodoPagoPreferido { get; set; }
        public string Observaciones { get; set; }
    }

    public class PersonaNegocio
    {
        private PersonaDatos _datos = new PersonaDatos();

        public Persona ObtenerPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return null;
            return _datos.BuscarPorDni(dni);
        }

        public List<Persona> BuscarPorApellido(string apellido) => _datos.BuscarPorTexto("Apellido", apellido);
        public List<Persona> BuscarPorNombres(string nombres) => _datos.BuscarPorTexto("Nombres", nombres);
        public List<Persona> BuscarPorCalle(string calle) => _datos.BuscarPorTexto("Calle", calle);

        public bool AgregarPersona(Persona p)
        {
            if (p == null) return false;
            if (string.IsNullOrWhiteSpace(p.Dni) || string.IsNullOrWhiteSpace(p.Apellido) || string.IsNullOrWhiteSpace(p.Nombres)) return false;

           
            if (_datos.BuscarPorDni(p.Dni) != null) return false;

            p.FechaAlta = DateTime.Now; 
            return _datos.Agregar(p);
        }

        public bool ModificarPersona(Persona p)
        {
            if (p == null) return false;
            if (string.IsNullOrWhiteSpace(p.Dni) || string.IsNullOrWhiteSpace(p.Apellido) || string.IsNullOrWhiteSpace(p.Nombres)) return false;

            return _datos.Modificar(p);
        }

        public bool EliminarPersona(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;
            return _datos.Eliminar(dni);
        }
    }
}