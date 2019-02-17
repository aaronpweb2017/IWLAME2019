using HolaMundo.Data;
using HolaMundo.Models;
using System.Collections.Generic;
using System.Linq;

namespace HolaMundo.Services
{
    public class PaisRepositorioEF : IRepositorioPais
    {
        public PaisRepositorioEF(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public ApplicationDbContext DbContext { get; } 

        public List<Pais> ObtenerTodos()
        {
            return DbContext.Paises.ToList();
        }
    }
}
