using HolaMundo.Services;
using Microsoft.AspNetCore.Mvc;

namespace HolaMundo.ViewComponents
{
    public class PaisesViewComponent : ViewComponent
    {
        public IRepositorioPais RepositorioPais { get;  }

        public PaisesViewComponent(IRepositorioPais RepositorioPais)
        {
            this.RepositorioPais = RepositorioPais;
        }

        public IViewComponentResult Invoke()
        {
            var paises = RepositorioPais.ObtenerTodos();
            return View(paises);
        }
    }
}