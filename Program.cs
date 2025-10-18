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

        //Constructor solicitado
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
                        Console.WriteLine("Opcion invalida. Intente de nuevo.");
                        break;
                }
            }
        }
        static void RegistrarPersona(List<Persona> personas)
        {
            try
            {
                Console.Write("Ingrese ID de la persona: ");
                int id = int.Parse(Console.ReadLine());

                // Validar ID único
                foreach (var p in personas)
                {
                    if (p.Id == id)
                    {
                        Console.WriteLine("El ID ya existe. Intente con otro.");
                        return;
                    }
                }

                Console.Write("Ingrese nombre: ");
                string nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacio.");
                    return;
                }

                Console.Write("Ingrese el numero de telefono: ");
                string telefono = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(telefono))
                {
                    Console.WriteLine("El telefono no puede estar vacio.");
                    return;
                }

                personas.Add(new Persona(id, nombre, telefono));
                Console.WriteLine($"Persona '{nombre}' registrada correctamente.");
            }
            catch
            {
                Console.WriteLine("Error: ingrese un numero valido para el ID.");
            }
        }

        static void ListarPersonas(List<Persona> personas)
        {
            if (personas.Count == 0)
            {
                Console.WriteLine("No hay personas registradas.");
                return;
            }

            Console.WriteLine("\n--- LISTA DE PERSONAS ---");
            foreach (var p in personas)
            {
                Console.WriteLine(p);
            }
        }

        static void CrearCita(List<Persona> personas, List<Cita> citas)
        {
            try
            {
                Console.Write("Ingrese el ID de la persona: ");
                int personaId = int.Parse(Console.ReadLine());

                // Validamos que el ID se encuentre en la lista
                Persona persona = personas.Find(p => p.Id == personaId);
                if (persona == null)
                {
                    Console.WriteLine("No existe una persona con ese ID.");
                    return;
                }

                Console.Write("Ingrese la fecha de la cita (dd/mm/yyyy): ");
                DateTime fecha = DateTime.Parse(Console.ReadLine());

                Console.Write("Ingrese descripción de la cita: ");
                string descripcion = Console.ReadLine();

                citas.Add(new Cita(personaId, fecha, descripcion));
                Console.WriteLine($"Cita registrada para {persona.Nombre} el {fecha.ToShortDateString()}.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: formato de fecha o numero invalido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        static void ListarCitasPorPersona(List<Cita> citas)
        {
            try
            {
                Console.Write("Ingrese el ID de la persona: ");
                int id = int.Parse(Console.ReadLine());

                var citasPersona = citas.FindAll(c => c.PersonaId == id);

                if (citasPersona.Count == 0)
                {
                    Console.WriteLine("No hay citas registradas para este ID.");
                    return;
                }

                Console.WriteLine($"\nCITAS DE LA PERSONA {id}");
                foreach (var c in citasPersona)
                {
                    Console.WriteLine(c);
                }
            }
            catch
            {
                Console.WriteLine("Error: ingrese un numero valido para el ID.");
            }
        }

        static void MostrarTodasLasCitas(List<Cita> citas)
        {
            if (citas.Count == 0)
            {
                Console.WriteLine("No hay citas registradas.");
                return;
            }

            Console.WriteLine("\nTODAS LAS CITAS AGENDADAS");
            foreach (var c in citas)
            {
                Console.WriteLine(c);
            }
        }
    }
}