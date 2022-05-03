using MvcPrimerExamenAWS.Data;
using MvcPrimerExamenAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPrimerExamenAWS.Repositories
{
    public class RepositoryApuestas
    {
        private ApuestasContext context;

        public RepositoryApuestas(ApuestasContext context)
        {
            this.context = context;
        }

        public List<Equipo> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }

        public List<Jugador> GetJugadores()
        {
            return this.context.Jugador.ToList();
        }

        public List<Apuesta> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }

        public int GetLastIdJugador()
        {
            var consulta = (from datos in this.context.Jugador select datos).OrderBy(x => x.IdJugador).LastOrDefault();

            if (consulta == null)
            {
                return 1;
            }

            int id = consulta.IdJugador;

            return id + 1;
        }

        public int GetLastIdApuesta()
        {
            var consulta = (from datos in this.context.Apuestas select datos).OrderBy(x => x.IdApuesta).LastOrDefault();

            if (consulta == null)
            {
                return 1;
            }

            int id = consulta.IdApuesta;

            return id + 1;
        }

        public void AddApuesta(Apuesta ap)
        {
            this.context.Apuestas.Add(ap);
            this.context.SaveChanges();
        }

        public void AddJugador(Jugador j)
        {
            this.context.Jugador.Add(j);
            this.context.SaveChanges();
        }
    }
}
