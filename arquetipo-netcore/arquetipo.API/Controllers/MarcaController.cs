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
    public class MarcaController : Controller
    {
        //private object servicio;

        //private object servicio;
        private readonly IMarca servicio;

        public MarcaController(IMarca _servicio)
        {
            servicio = _servicio;
        }


        // GET: api/Blog
        [HttpGet]
        public async Task<Respuesta> GetMarcas()
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetMarcas();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<Respuesta> GetMarca(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetMarca(id);
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
        [Route("CrearMarca")]
        public async Task<Respuesta> CrearMarca(Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearMarca(oMarca);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<Respuesta> EditarMarca(int id, Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != oMarca.MaCodigo)
                {
                    respuesta.Message = $"El id no coincide: {id}";
                }
                else
                {
                    respuesta.Resultado = await servicio.EditarMarca(oMarca);
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
        public async Task<Respuesta> EliminarMarca(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarMarca(id);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;

        }
    }
}
