//Se agrega el método y se realiza el llamado. 
using System; //Importa Namespaces de system. 
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic; 

namespace MascotaFeliz.App.Consola //Contenedor para clases y otros namespace.
{
    class Program //Contenedor de datos y métodos.
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); //Método que se usa para imprimir un texto.
            //AddDueno();
            //AddVeterinario();
            //AddMascota();
            //BuscarMascota(1);
            //BuscarTodasMascotas();
        }

        private static void AddDueno()
        {
            var dueno = new Dueno 
            {
                Nombres = "Flor",
                Apellidos ="Campo",
                Direccion = "Calle Falsa",
                Telefono = "963852741",
                Correo = "FlordelCampo@gmail.com"
            };

            _repoDueno.AddDueno(dueno);
        }

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario 
            {
                Nombres = "Olga",
                Apellidos ="Holguín",
                Direccion = "Casa 248",
                Telefono = "74125479",
                TarjetaProfesional = "147741258"
            };

            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void AddMascota()
        {
            var mascota = new Mascota 
            {
                Nombre = "Alfred",
                Color ="Café",
                Especie = "Gato",
                Raza = "Bengalí",
            };

            _repoMascota.AddMascota(mascota);
        }

        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
        } 

        private static void BuscarTodasMascotas()
        {
            var mascotas = _repoMascota.GetAllMascotas();
            
            foreach(Mascota m in mascotas)
            {
                Console.WriteLine(m.Nombre);
            }
        }  

        
    }
}
