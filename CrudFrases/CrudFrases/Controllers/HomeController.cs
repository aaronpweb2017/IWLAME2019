using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudFrases.Models;
using CrudFrases.Services;

namespace CrudFrases.Controllers
{
    public class HomeController : Controller
    {

        public IRepositorioFrase Repositorio { get; }

        public HomeController(IRepositorioFrase Repositorio)
        {
            this.Repositorio = Repositorio;
        }

        public IActionResult Index()
        {
            var frases = Repositorio.GetAll();
            return View(frases);
        }

        public IActionResult Privacy()
        {
            var frases = Repositorio.GetAll();
            return View(frases);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
