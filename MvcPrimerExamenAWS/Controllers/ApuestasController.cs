using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcPrimerExamenAWS.Models;
using MvcPrimerExamenAWS.Repositories;
using MvcPrimerExamenAWS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPrimerExamenAWS.Controllers
{
    public class ApuestasController : Controller
    {
        private RepositoryApuestas repo;
        private ServiceAWSS3 service;
        public ApuestasController(RepositoryApuestas repo, ServiceAWSS3 service)
        {
            this.repo = repo;
            this.service = service;
        }

        public IActionResult Equipos()
        {
            return View(this.repo.GetEquipos());
        }

        public IActionResult Jugadores()
        {
            return View(this.repo.GetJugadores());
        }

        public IActionResult NuevoJugador()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NuevoJugador(string nombre, string posicion, int idequipo, IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, file.FileName);
            }

            Jugador j = new Jugador()
            {
                IdJugador=this.repo.GetLastIdJugador(),
                Nombre=nombre,
                Posicion=posicion,
                IdEquipo=idequipo,
                Imagen=file.FileName
            };

            this.repo.AddJugador(j);
            return RedirectToAction("Jugadores");
        }

        public IActionResult Apuestas()
        {            
            return View(this.repo.GetApuestas());
        }

        public IActionResult NuevaApuesta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NuevaApuesta(string usuario, int goleslocal, int golesvisitante)
        {
            Apuesta ap = new Apuesta()
            {
                IdApuesta=this.repo.GetLastIdApuesta(),
                Usuario=usuario,
                IdEquipoLocal=1,
                IdEquipoVisitante=2,
                GolesLocal=goleslocal,
                GolesVisitante=golesvisitante
            };
            this.repo.AddApuesta(ap);
            return RedirectToAction("Apuestas");
        }
    }
}
