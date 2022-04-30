using Microsoft.AspNetCore.Mvc;
using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Threading.Tasks;
using System;

namespace arquetipo.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutomovilController : Controller
    {

        //private object servicio;
        private readonly IAutomovil servicio;

        public AutomovilController(IAutomovil _servicio)
        {

            servicio = _servicio;

        }

        // GET: api/Blog
        [HttpGet]
        public async Task<Respuesta> GetAutomovils()
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetAutomoviles();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<Respuesta> GetAutomovil(string id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetAutomovil(id);
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
        [Route("CrearAutomovil")]
        public async Task<Respuesta> CrearAutomovil(Automovil oAutomovil)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearAutomovil(oAutomovil);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        // PUT: api/Automovils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<Respuesta> EditarAutomovil(string id, Automovil oAutomovil)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != oAutomovil.AuPlaca)
                {
                    respuesta.Message = $"El id no coincide: {id}";
                }
                else
                {
                    respuesta.Resultado = await servicio.EditarAutomovil(oAutomovil);
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
        public async Task<Respuesta> EliminarAutomovil(string id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarAutomovil(id);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;

        }
    }
}
