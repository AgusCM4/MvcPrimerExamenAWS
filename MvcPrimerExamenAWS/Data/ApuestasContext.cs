using Microsoft.EntityFrameworkCore;
using MvcPrimerExamenAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPrimerExamenAWS.Data
{
    public class ApuestasContext:DbContext
    {
        public ApuestasContext(DbContextOptions<ApuestasContext> options) : base(options) { }

        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugador { get; set; }
    }
}
