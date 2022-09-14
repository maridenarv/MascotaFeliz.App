using System;
using System.Collections.Generic; // Sirve como un import

namespace MascotaFeliz.App.Dominio //Paquete
{
    public class Historia
    {
        public int Id {get;set;}
        public DateTime FechaInicial {get;set;}
        public List<VisitaPyP> VisitasPyP {get;set;}
    }
}