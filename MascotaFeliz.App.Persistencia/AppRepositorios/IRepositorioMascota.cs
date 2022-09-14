//Interfaz: conjunto de métodos y propiedades que no tiene ninguna implementación. 
//La implementación la hace c/u de los elementos que herede de la interfaz.
//Interfaz firma los métodos , es decir, define entrada y salida de los métodos.
// Incluye en nombre del método "AddMascota" y sus parametros (Mascota (Clase) y mascota (nuevo elemento de la clase mascota)).
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascotas();
        Mascota AddMascota(Mascota mascota); 
        Mascota UpdateMascota(Mascota mascota);
        void DeleteMascota(int idMascota);
        Mascota GetMascota(int idMascota);
        IEnumerable<Mascota> GetMascotasPorFiltro(string filtro);
    }
}