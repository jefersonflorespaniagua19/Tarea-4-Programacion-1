using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaContactos
{
    // Clase que representa un Contacto
    public class Contacto
    {
        // Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        // Constructor
        public Contacto(int id, string nombre, string telefono, string email, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
        }

        // Método para mostrar la información del contacto
        public void MostrarInformacion()
        {
            Console.WriteLine($"{Id,-5} {Nombre,-20} {Telefono,-15} {Email,-25} {Direccion,-30}");
        }

        // Método para actualizar la información
        public void ActualizarInformacion(string nombre, string telefono, string email, string direccion)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
        }
    }

    // Clase que maneja la Agenda de contactos
    public class Agenda
    {
        // Lista privada de contactos (Encapsulamiento)
        private List<Contacto> contactos;
        private int siguienteId;

        // Constructor
        public Agenda()
        {
            contactos = new List<Contacto>();
            siguienteId = 1;
        }

        // Método para agregar un contacto
        public void AgregarContacto(string nombre, string telefono, string email, string direccion)
        {
            Contacto nuevoContacto = new Contacto(siguienteId, nombre, telefono, email, direccion);
            contactos.Add(nuevoContacto);
            siguienteId++;
            Console.WriteLine("\n✓ Contacto agregado exitosamente!");
        }

        // Método para ver todos los contactos
        public void VerContactos()
        {
            Console.WriteLine("\n=== LISTA DE CONTACTOS ===");
            if (contactos.Count == 0)
            {
                Console.WriteLine("No hay contactos registrados.");
                return;
            }

            Console.WriteLine($"{"Id",-5} {"Nombre",-20} {"Teléfono",-15} {"Email",-25} {"Dirección",-30}");
            Console.WriteLine(new string('=', 100));

            foreach (var contacto in contactos)
            {
                contacto.MostrarInformacion();
            }
        }

        // Método para buscar un contacto por ID
        public Contacto BuscarContactoPorId(int id)
        {
            return contactos.FirstOrDefault(c => c.Id == id);
        }

        // Método para buscar contactos por nombre
        public List<Contacto> BuscarContactosPorNombre(string nombre)
        {
            return contactos.Where(c => c.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
        }

        // Método para buscar contactos por teléfono
        public List<Contacto> BuscarContactosPorTelefono(string telefono)
        {
            return contactos.Where(c => c.Telefono.Contains(telefono)).ToList();
        }

        // Método para modificar un contacto
        public bool ModificarContacto(int id, string nombre, string telefono, string email, string direccion)
        {
            Contacto contacto = BuscarContactoPorId(id);
            if (contacto != null)
            {
                contacto.ActualizarInformacion(nombre, telefono, email, direccion);
                Console.WriteLine("\n✓ Contacto modificado exitosamente!");
                return true;
            }
            Console.WriteLine("\nError: Contacto no encontrado.");
            return false;
        }

        // Método para eliminar un contacto
        public bool EliminarContacto(int id)
        {
            Contacto contacto = BuscarContactoPorId(id);
            if (contacto != null)
            {
                contactos.Remove(contacto);
                Console.WriteLine("\n✓ Contacto eliminado exitosamente!");
                return true;
            }
            Console.WriteLine("\nError: Contacto no encontrado.");
            return false;
        }

        // Método para obtener la cantidad de contactos
        public int ObtenerCantidadContactos()
        {
            return contactos.Count;
        }
    }

    // Clase que maneja la interfaz de usuario (Menú)
    public class MenuAgenda
    {
        private Agenda agenda;

        // Constructor
        public MenuAgenda()
        {
            agenda = new Agenda();
        }

        // Método principal para iniciar el menú
        public void Iniciar()
        {
            Console.WriteLine("Mi Agenda Perrón");
            Console.WriteLine("Bienvenido a tu lista de contactes\n");

            bool running = true;
            while (running)
            {
                MostrarMenu();
                int opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        ProcesarAgregarContacto();
                        break;
                    case 2:
                        agenda.VerContactos();
                        break;
                    case 3:
                        ProcesarBuscarContacto();
                        break;
                    case 4:
                        ProcesarModificarContacto();
                        break;
                    case 5:
                        ProcesarEliminarContacto();
                        break;
                    case 6:
                        running = false;
                        Console.WriteLine("\n¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        // Método para mostrar el menú
        private void MostrarMenu()
        {
            Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Ver Contactos");
            Console.WriteLine("3. Buscar Contactos");
            Console.WriteLine("4. Modificar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Salir");
            Console.Write("\nElige una opción: ");
        }

        // Método para leer la opción del usuario
        private int LeerOpcion()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                return -1;
            }
        }

        // Método para procesar la opción de agregar contacto
        private void ProcesarAgregarContacto()
        {
            Console.WriteLine("\n=== AGREGAR CONTACTO ===");
            Console.Write("Digite el Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Digite el Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Digite el Email: ");
            string email = Console.ReadLine();
            Console.Write("Digite la dirección: ");
            string direccion = Console.ReadLine();

            agenda.AgregarContacto(nombre, telefono, email, direccion);
        }

        // Método para procesar la búsqueda de contactos
        private void ProcesarBuscarContacto()
        {
            Console.WriteLine("\n=== BUSCAR CONTACTO ===");
            Console.WriteLine("1. Buscar por ID");
            Console.WriteLine("2. Buscar por Nombre");
            Console.WriteLine("3. Buscar por Teléfono");
            Console.Write("Elija un método de búsqueda: ");

            int opcionBusqueda = LeerOpcion();

            switch (opcionBusqueda)
            {
                case 1:
                    BuscarPorId();
                    break;
                case 2:
                    BuscarPorNombre();
                    break;
                case 3:
                    BuscarPorTelefono();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        // Método para buscar por ID
        private void BuscarPorId()
        {
            Console.Write("Digite el ID del contacto: ");
            int id = LeerOpcion();
            Contacto contacto = agenda.BuscarContactoPorId(id);

            if (contacto != null)
            {
                Console.WriteLine("\n=== CONTACTO ENCONTRADO ===");
                Console.WriteLine($"{"Id",-5} {"Nombre",-20} {"Teléfono",-15} {"Email",-25} {"Dirección",-30}");
                Console.WriteLine(new string('=', 100));
                contacto.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("\nContacto no encontrado.");
            }
        }

        // Método para buscar por nombre
        private void BuscarPorNombre()
        {
            Console.Write("Digite el nombre a buscar: ");
            string nombre = Console.ReadLine();
            List<Contacto> encontrados = agenda.BuscarContactosPorNombre(nombre);

            if (encontrados.Count > 0)
            {
                Console.WriteLine($"\n=== SE ENCONTRARON {encontrados.Count} CONTACTO(S) ===");
                Console.WriteLine($"{"Id",-5} {"Nombre",-20} {"Teléfono",-15} {"Email",-25} {"Dirección",-30}");
                Console.WriteLine(new string('=', 100));
                foreach (var contacto in encontrados)
                {
                    contacto.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontraron contactos.");
            }
        }

        // Método para buscar por teléfono
        private void BuscarPorTelefono()
        {
            Console.Write("Digite el teléfono a buscar: ");
            string telefono = Console.ReadLine();
            List<Contacto> encontrados = agenda.BuscarContactosPorTelefono(telefono);

            if (encontrados.Count > 0)
            {
                Console.WriteLine($"\n=== SE ENCONTRARON {encontrados.Count} CONTACTO(S) ===");
                Console.WriteLine($"{"Id",-5} {"Nombre",-20} {"Teléfono",-15} {"Email",-25} {"Dirección",-30}");
                Console.WriteLine(new string('=', 100));
                foreach (var contacto in encontrados)
                {
                    contacto.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("\nNo se encontraron contactos.");
            }
        }

        // Método para procesar la modificación de un contacto
        private void ProcesarModificarContacto()
        {
            Console.WriteLine("\n=== MODIFICAR CONTACTO ===");
            agenda.VerContactos();

            if (agenda.ObtenerCantidadContactos() == 0)
            {
                return;
            }

            Console.Write("\nDigite el ID del contacto a modificar: ");
            int id = LeerOpcion();

            Contacto contacto = agenda.BuscarContactoPorId(id);
            if (contacto == null)
            {
                Console.WriteLine("\nContacto no encontrado.");
                return;
            }

            Console.WriteLine("\n=== INFORMACIÓN ACTUAL ===");
            Console.WriteLine($"Nombre: {contacto.Nombre}");
            Console.WriteLine($"Teléfono: {contacto.Telefono}");
            Console.WriteLine($"Email: {contacto.Email}");
            Console.WriteLine($"Dirección: {contacto.Direccion}");

            Console.WriteLine("\n=== NUEVA INFORMACIÓN ===");
            Console.Write("Nuevo Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Nuevo Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Nuevo Email: ");
            string email = Console.ReadLine();
            Console.Write("Nueva Dirección: ");
            string direccion = Console.ReadLine();

            agenda.ModificarContacto(id, nombre, telefono, email, direccion);
        }

        // Método para procesar la eliminación de un contacto
        private void ProcesarEliminarContacto()
        {
            Console.WriteLine("\n=== ELIMINAR CONTACTO ===");
            agenda.VerContactos();

            if (agenda.ObtenerCantidadContactos() == 0)
            {
                return;
            }

            Console.Write("\nDigite el ID del contacto a eliminar: ");
            int id = LeerOpcion();

            Contacto contacto = agenda.BuscarContactoPorId(id);
            if (contacto == null)
            {
                Console.WriteLine("\nContacto no encontrado.");
                return;
            }

            Console.WriteLine($"\n¿Está seguro de eliminar a {contacto.Nombre}?");
            Console.WriteLine("1. Sí");
            Console.WriteLine("2. No");
            Console.Write("Opción: ");

            int confirmacion = LeerOpcion();
            if (confirmacion == 1)
            {
                agenda.EliminarContacto(id);
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }
        }
    }

    // Clase principal del programa
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuAgenda menu = new MenuAgenda();
            menu.Iniciar();

            Console.ReadKey();
        }
    }
}