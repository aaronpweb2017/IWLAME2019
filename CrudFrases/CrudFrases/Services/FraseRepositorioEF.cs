using CrudFrases.Data;
using CrudFrases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFrases.Services
{
    public class FraseRepositorioEF : IRepositorioFrase
    {
        public ApplicationDbContext DbContext { get; }

        public FraseRepositorioEF(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public List<Frase> GetAll()
        {
            return DbContext.Frases.ToList();
        }
    }
}
