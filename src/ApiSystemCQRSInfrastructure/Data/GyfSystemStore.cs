using ApiSystemCQRSDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystemCQRSInfrastructure.Data
{
    public static class GyfSystemStore
    {
        public static List<GyfSystemModels> GyfSystemsList = new List<GyfSystemModels>
        {
                new GyfSystemModels{ Id=1 , Name="SuperApp", Description = "Sistema que se encarga de la Fe de vida!", User ="Admin", License="Anual"},
                new GyfSystemModels{ Id=2 , Name="Adintar", Description = "Solución para la gestión de tarjetas de crédito", User ="Admin", License="Mensual"},
                new GyfSystemModels{ Id=3 , Name="Cash Dispenser", Description = "Cajero Automaticos", User ="Admin", License="Anual"},
                new GyfSystemModels{ Id=4 , Name="Cambio Divisas", Description = "Aplicación mobile de cambio de divisas", User ="Admin", License="Mensual"},
                new GyfSystemModels{ Id=5 , Name="Modo", Description = "Backend de Modo", User ="Admin", License="Anual"}
        };
    }
}
