using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebProspectos.Models
{
    public class WebContext : DbContext
    {
        public WebContext()
            : base("DefaultConection")
        {
            
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
    }
}