using HolaMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaMundo.Services
{
    public class PaisRepositorioEnMemoria : IRepositorioPais
    {
        public List<Pais> ObtenerTodos() {
            List<Pais> paises = new List<Pais>();
            for (int i = 0; i < 5; i++)
                paises.Add(new Pais((i+1),"país número " + (i + 1)));
            return paises;
        }
    }
}