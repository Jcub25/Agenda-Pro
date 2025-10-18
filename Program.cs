using System;
using System.Collections.Generic;

namespace AgendaPro
{
    // Creacion de la clase persona con constructor
    class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public Persona(int id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"{Id} | {Nombre} | {Telefono}";
        }
    }

    // Creacion de clase Cita con atributos
    class Cita
    {
        public int PersonaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public Cita(int personaId, DateTime fecha, string descripcion)
        {
            PersonaId = personaId;
            Fecha = fecha;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return $"{PersonaId} | {Fecha.ToShortDateString()} | {Descripcion}";
        }
    }
