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
    // Programa principal Menu
    class Program
    {
        static void Main()
        {
            List<Persona> personas = new List<Persona>();
            List<Cita> citas = new List<Cita>();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nMENU PRINCIPAL - AgendaPro");
                Console.WriteLine("1. Registrar persona");
                Console.WriteLine("2. Listar personas");
                Console.WriteLine("3. Crear cita");
                Console.WriteLine("4. Listar citas por PersonaId");
                Console.WriteLine("5. Mostrar todas las citas");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarPersona(personas);
                        break;

                    case "2":
                        ListarPersonas(personas);
                        break;

                    case "3":
                        CrearCita(personas, citas);
                        break;

                    case "4":
                        ListarCitasPorPersona(citas);
                        break;

                    case "5":
                        MostrarTodasLasCitas(citas);
                        break;

                    case "6":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción invalida. Intente de nuevo.");
                        break;
                }
            }
        }