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
    public class PatioAutoController : Controller
    {
        //private object servicio;
        private readonly IPatioAuto servicio;

        public PatioAutoController(IPatioAuto _servicio)
        {

            servicio = _servicio;

        }

        // GET: api/Blog
        [HttpGet]
        public async Task<Respuesta> GetPatioAutos()
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetPatioAutos();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<Respuesta> GetPatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetPatioAuto(id);
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
        [Route("CrearPatioAuto")]
        public async Task<Respuesta> CrearPatioAuto(PatioAuto oPatioAuto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearPatioAuto(oPatioAuto);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        // PUT: api/PatioAutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<Respuesta> EditarPatioAuto(int id, PatioAuto oPatioAuto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != oPatioAuto.PaNumeroPatio)
                {
                    respuesta.Message = $"El id no coincide: {id}";
                }
                else
                {
                    respuesta.Resultado = await servicio.EditarPatioAuto(oPatioAuto);
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
        public async Task<Respuesta> EliminarPatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarPatioAuto(id);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;

        }

    }
}
