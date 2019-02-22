using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HolaMundo.Models;

namespace HolaMundo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pais> Paises { get; set; } 
        //Comandos para agregar una migración que actualice la base de datos:
        //Add-Migration Agregar_Paises
        //update-database
    }
}
