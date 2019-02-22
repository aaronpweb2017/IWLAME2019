using CrudFrases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFrases.Services
{
    public interface IRepositorioFrase
    {
        List<Frase> GetAll();
    }
}
