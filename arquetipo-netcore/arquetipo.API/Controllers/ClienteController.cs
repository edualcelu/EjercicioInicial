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
    public class ClienteController : ControllerBase
    {
        //private object servicio;
        private readonly ICliente servicio;
        
        public ClienteController(ICliente _servicio){

           servicio = _servicio;

        }

        // GET: api/Blog
        [HttpGet]
        [Route("CargarCliente")]
        public async Task<Respuesta> CargarCliente()
        {

            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CargarClientes();
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
        public async Task<Respuesta> GetClientes()
        {
             
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetClientes();
                respuesta.IsSuccess = true;
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<Respuesta> GetCliente(string id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta.Resultado = await servicio.GetCliente(id);
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
        [Route("CrearCliente")]
        public async Task<Respuesta> CrearCliente(Cliente oCLiente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearCliente(oCLiente);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        
        public async Task<Respuesta> EditarCliente(string id, Cliente oCliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != oCliente.ClIdentificacion)
                {
                    respuesta.Message = $"El id no coincide: {id}";
                }
                else
                {
                    respuesta.Resultado = await servicio.EditarCliente(oCliente);
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
        public async Task<Respuesta> EliminarCliente(string id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarCliente(id);
            }
            catch (Exception e)
            {
                respuesta.Message = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;

        }
    }
}