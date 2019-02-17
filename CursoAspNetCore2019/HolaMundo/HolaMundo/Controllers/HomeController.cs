using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HolaMundo.Models;
using HolaMundo.Services;

namespace HolaMundo.Controllers
{
    public class HomeController : Controller
    {
        public IRepositorioPais Repositorio { get; }

        public HomeController(IRepositorioPais Repositorio)
        {
            this.Repositorio = Repositorio;
        }
        public IActionResult Index()
        {
            //throw new ApplicationException("Ha ocurrido un error");
            var paises = Repositorio.ObtenerTodos();
            return View(paises);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
