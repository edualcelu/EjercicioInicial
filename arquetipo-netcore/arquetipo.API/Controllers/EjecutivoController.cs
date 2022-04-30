using Microsoft.AspNetCore.Mvc;
using arquetipo.Infrastructure.Services;
using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Threading.Tasks;
using System;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EjecutivoController : Controller
    {
       //private object servicio;
        private readonly IEjecutivo servicio;

        public EjecutivoController(IEjecutivo _servicio)
        {
            servicio = _servicio;
        }

        // GET: api/Blog
        [HttpGet]
        [Route("CargarEjecutivo")]
        public async Task<Respuesta> CargarEjecutivo()
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CargarEjecutivos();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }



        // GET: api/Blog
        [HttpGet]
        public async Task<Respuesta> GetEjecutivos()
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetEjecutivos();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<Respuesta> GetEjecutivo(string id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetEjecutivo(id);
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }


        // POST: api/Movimientos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("CrearEjecutivo")]
        public async Task<Respuesta> CrearEjecutivo(Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearEjecutivo(oEjecutivo);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        // PUT: api/Ejecutivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<Respuesta> EditarEjecutivo(string id, Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != oEjecutivo.EIdentificacion)
                {
                    respuesta.Message = $"El id no coincide: {id}";
                }
                else
                {
                    respuesta.Resultado = await servicio.EditarEjecutivo(oEjecutivo);
                    respuesta.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;

        }


        // DELETE: api/Cuentas/5
        [HttpDelete("{id}")]
        public async Task<Respuesta> EliminarEjecutivo(string id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarEjecutivo(id);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;

        }
    }
}
