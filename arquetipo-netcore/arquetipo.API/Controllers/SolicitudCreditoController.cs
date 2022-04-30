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
    public class SolicitudCreditoController : ControllerBase
    {
        //private object servicio;
        private readonly ISolicitudCredito servicio;

        public SolicitudCreditoController(ISolicitudCredito _servicio)
        {

            servicio = _servicio;

        }

        // GET: api/Blog
        [HttpGet]
        public async Task<Respuesta> GetSolicitudCreditos()
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetSolicitudCreditos();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<Respuesta> GetSolicitudCredito(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetSolicitudCredito(id);
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
        [Route("CrearSolicitudCredito")]
        public async Task<Respuesta> CrearSolicitudCredito(SolicitudCredito oSolicitudCredito)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearSolicitudCredito(oSolicitudCredito);
            }
            catch (Exception e)
                {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        // PUT: api/SolicitudCreditos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<Respuesta> EditarSolicitudCredito(int id, SolicitudCredito oSolicitudCredito)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != oSolicitudCredito.ScIdSolicitudCredito)
                {
                    respuesta.Message = $"El id no coincide: {id}";
                }
                else
                {
                    respuesta.Resultado = await servicio.EditarSolicitudCredito(oSolicitudCredito);
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
        public async Task<Respuesta> EliminarSolicitudCredito(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarSolicitudCredito(id);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;

        }
    }
}
