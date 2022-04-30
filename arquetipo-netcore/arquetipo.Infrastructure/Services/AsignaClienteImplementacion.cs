using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using arquetipo.Repository.Context;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.Infrastructure.Services
{
    public class AsignaClienteImplementacion : IAsignaCliente
    {
        private readonly BlogContext _context;

        public AsignaClienteImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AsignaCliente>> GetAsignaClientes()
        {
            return await _context.AsignaClientes.ToListAsync();
        }

        public async Task<AsignaCliente> GetAsignaCliente(string id)
        {
            return await _context.AsignaClientes.FirstOrDefaultAsync(x => x.AcIdentificacion == id);
        }

        public async Task<Respuesta> CrearAsignaCliente(AsignaCliente oAsignaCliente)
        {
            Respuesta respuesta = new Respuesta();
            ClienteImplementacion oClienteImplementacion = new ClienteImplementacion(_context);
            Cliente cliente = await oClienteImplementacion.GetCliente(oAsignaCliente.AcIdentificacion);

            PatioAutoImplementacion oPatioAutoImplementacion = new PatioAutoImplementacion(_context);
            PatioAuto oPatioAuto = await oPatioAutoImplementacion.GetPatioAuto(oAsignaCliente.AcNumeroPatio);
            if (cliente == null || oPatioAuto == null)
            {
                respuesta.Message = $"La identificación ya esta registrada:{oAsignaCliente.AcIdentificacion} ";
            }
            else
            {
                _context.AsignaClientes.Add(oAsignaCliente);
                respuesta.Message = $"Registrado correctamente:{oAsignaCliente.AcIdentificacion} ";
                respuesta.IsSuccess = true;
                await _context.SaveChangesAsync();
            }
            return respuesta;
        }

        public async Task<AsignaCliente> EditarAsignaCliente(AsignaCliente oAsignaCliente)
        {

            _context.Entry(oAsignaCliente).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return oAsignaCliente;

        }
        public async Task<Respuesta> EliminarAsignaCliente(string id)
        {
            Respuesta respuesta = new Respuesta();


            var pCuenta = await _context.AsignaClientes.FindAsync(id);
            if (pCuenta == null)
            {
                respuesta.Message = $"No existe el AsignaCliente {id}";
                return respuesta;
            }

            _context.AsignaClientes.Remove(pCuenta);
            await _context.SaveChangesAsync();
            respuesta.Message = $"El id: {id} se a eliminado correctamente";
            respuesta.IsSuccess = true;
            return respuesta;
        }

    }
}
