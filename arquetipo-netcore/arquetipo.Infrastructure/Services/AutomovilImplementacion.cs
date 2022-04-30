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

    public class AutomovilImplementacion : IAutomovil
    {
        private readonly BlogContext _context;
       
        public AutomovilImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Automovil>> GetAutomoviles()
        {
            return await _context.Automovils.ToListAsync();
        }

        public async Task<Automovil> GetAutomovil(string id)
        {
            return await _context.Automovils.FirstOrDefaultAsync(x => x.AuPlaca == id);
        }

        public async Task<Respuesta> CrearAutomovil(Automovil oAutomovil)
        {
            Respuesta respuesta = new Respuesta();
            Automovil Automovil = await GetAutomovil(oAutomovil.AuPlaca);
            MarcaImplementacion oMarcaImplementacion = new MarcaImplementacion(_context);
            Marca marca = await oMarcaImplementacion.GetMarca(oAutomovil.AuCodigoMarca);
            if (Automovil != null || marca == null)
            {
                respuesta.Message = $"La identificación ya esta registrada:{oAutomovil.AuPlaca}";
            }
            else
            {
                _context.Automovils.Add(oAutomovil);
                respuesta.Message = $"Registrado correctamente:{oAutomovil.AuPlaca} ";
                respuesta.IsSuccess = true;
                await _context.SaveChangesAsync();
            }
            return respuesta;
        }

        public async Task<Automovil> EditarAutomovil(Automovil oAutomovil)
        {

            _context.Entry(oAutomovil).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return oAutomovil;

        }
        public async Task<Respuesta> EliminarAutomovil(string id)
        {
            Respuesta respuesta = new Respuesta();


            var pCuenta = await _context.Automovils.FindAsync(id);
            if (pCuenta == null)
            {
                respuesta.Message = $"No existe el Automovil {id}";
                return respuesta;
            }

            _context.Automovils.Remove(pCuenta);
            await _context.SaveChangesAsync();
            respuesta.Message = $"El id: {id} se a eliminado correctamente";
            respuesta.IsSuccess = true;
            return respuesta;
        }
    }
}
