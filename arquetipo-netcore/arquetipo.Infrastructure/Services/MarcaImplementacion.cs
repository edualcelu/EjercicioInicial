using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace arquetipo.Infrastructure.Services
{
    public class MarcaImplementacion : IMarca
    {
        private readonly BlogContext _context;
        public MarcaImplementacion(BlogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Marca>> GetMarcas()
        {
            return await _context.Marcas.ToListAsync();
        }

        public async Task<Marca> GetMarca(int id)
        {
            return await _context.Marcas.FirstOrDefaultAsync(x => x.MaCodigo == id);
        }

        public async Task<Respuesta> CrearMarca(Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            _context.Marcas.Add(oMarca);
            respuesta.Message = $"Registrado correctamente";
            respuesta.IsSuccess = true;
            await _context.SaveChangesAsync();
            
            return respuesta;
        }

        public async Task<Marca> EditarMarca(Marca oMarca)
        {

            _context.Entry(oMarca).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return oMarca;

        }
        public async Task<Respuesta> EliminarMarca(int id)
        {
            Respuesta respuesta = new Respuesta();


            var pCuenta = await _context.Marcas.FindAsync(id);
            if (pCuenta == null)
            {
                respuesta.Message = $"No existe el Marca {id}";
                return respuesta;
            }

            _context.Marcas.Remove(pCuenta);
            await _context.SaveChangesAsync();
            respuesta.Message = $"El id: {id} se a eliminado correctamente";
            respuesta.IsSuccess = true;
            return respuesta;
        }
    }
}
