// Aquí se implementan todos los métodos de IRepositorioMascota.cs
using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota // Herencia de la interfaz. 
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Mascota AddMascota(Mascota mascota)   //2
        {
            var mascotaAdicionado = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionado.Entity;
        }

        public void DeleteMascota(int idMascota) //4
        {
            var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
            if (mascotaEncontrado == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrado);
            _appContext.SaveChanges();
        } 

        public IEnumerable<Mascota> GetAllMascotas() //1
        {
            return _appContext.Mascotas;
        }

        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro) //6
        {
            var mascotas = GetAllMascotas(); // Obtiene todos los saludos
            if (mascotas != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascotas = mascotas.Where(s => s.Nombre.Contains(filtro)); //?
                }
            }
            return mascotas;
        }


        public Mascota GetMascota(int idMascota) //consultar 1 mascota //5
        {
            return _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
        }

        public Mascota UpdateMascota(Mascota mascota) //3
        {
             var mascotaEncontrado = _appContext.Mascotas.FirstOrDefault(d => d.Id == mascota.Id);
             if (mascotaEncontrado != null)
             {
                 mascotaEncontrado.Nombre = mascota.Nombre;
                 mascotaEncontrado.Color = mascota.Color;
                 mascotaEncontrado.Especie = mascota.Especie;
                 mascotaEncontrado.Raza = mascota.Raza;
                 _appContext.SaveChanges();
             }
             return mascotaEncontrado;
         }     
    }
}