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
    public class PatioAutoImplementacion : IPatioAuto
    {
        private readonly BlogContext _context;
        

        public PatioAutoImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatioAuto>> GetPatioAutos()
        {
            return await _context.PatioAutos.ToListAsync();
        }

        public async Task<PatioAuto> GetPatioAuto(int id)
        {
            return await _context.PatioAutos.FirstOrDefaultAsync(x => x.PaNumeroPatio == id);
        }

        public async Task<Respuesta> CrearPatioAuto(PatioAuto oPatioAuto)
        {
            Respuesta respuesta = new Respuesta();
            _context.PatioAutos.Add(oPatioAuto);
            respuesta.Message = $"Registrado correctamente";
            respuesta.IsSuccess = true;
            await _context.SaveChangesAsync();
            return respuesta;
        }

        public async Task<PatioAuto> EditarPatioAuto(PatioAuto oPatioAuto)
        {

            _context.Entry(oPatioAuto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return oPatioAuto;

        }
        public async Task<Respuesta> EliminarPatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();

            var pCuenta = await _context.PatioAutos.FindAsync(id);
            if (pCuenta == null)
            {
                respuesta.Message = $"No existe el PatioAuto {id}";
                return respuesta;
            }

            _context.PatioAutos.Remove(pCuenta);
            await _context.SaveChangesAsync();
            respuesta.Message = $"El id: {id} se a eliminado correctamente";
            respuesta.IsSuccess = true;
            return respuesta;
        }
    }
}
