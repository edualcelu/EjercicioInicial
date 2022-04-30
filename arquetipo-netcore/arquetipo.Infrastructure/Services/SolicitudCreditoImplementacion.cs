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
    public class SolicitudCreditoImplementacion : ISolicitudCredito
    {
        private readonly BlogContext _context;

        public enum DivisionStatus
        {
            Soltero = 'S',
            Casado = 'C',
            Divorciado = 'D',
        }

        public SolicitudCreditoImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SolicitudCredito>> GetSolicitudCreditos()
        {
            return await _context.SolicitudCreditos.ToListAsync();
        }

        public async Task<SolicitudCredito> GetSolicitudCredito(int id)
        {
            return await _context.SolicitudCreditos.FirstOrDefaultAsync(x => x.ScIdSolicitudCredito == id);
        }

        public async Task<Respuesta> CrearSolicitudCredito(SolicitudCredito oSolicitudCredito)
        {
            Respuesta respuesta = new Respuesta();

            oSolicitudCredito.ScFechaElaboracion = DateTime.Now.Date;
           
            SolicitudCredito oSolicitudCreditoConsulta = await _context.SolicitudCreditos.FirstOrDefaultAsync(x => x.ScIdentificacionCliente == oSolicitudCredito.ScIdentificacionCliente && x.ScFechaElaboracion.Date == oSolicitudCredito.ScFechaElaboracion);
            AsignaClienteImplementacion asignaClienteImplementacion = new AsignaClienteImplementacion(_context);
            
            
            if (oSolicitudCreditoConsulta != null)
            {
                respuesta.Message = $"La identificación ya esta registrada:{oSolicitudCredito.ScIdSolicitudCredito} ";
            }
            else
            {
                _context.SolicitudCreditos.Add(oSolicitudCredito);
                await _context.SaveChangesAsync();

                AsignaCliente oAsignaCliente = new AsignaCliente();
                oAsignaCliente.AcIdentificacion = oSolicitudCredito.ScIdentificacionCliente;
                oAsignaCliente.AcNumeroPatio = oSolicitudCredito.ScNumeroPatio;
                oAsignaCliente.AcFechaAsignacion = oSolicitudCredito.ScFechaElaboracion;
                await asignaClienteImplementacion.CrearAsignaCliente(oAsignaCliente);

                respuesta.Message = $"Registrado correctamente:{oSolicitudCredito.ScIdSolicitudCredito} ";
                respuesta.IsSuccess = true;
            }
            return respuesta;
        }

        public async Task<SolicitudCredito> EditarSolicitudCredito(SolicitudCredito oSolicitudCredito)
        {

            _context.Entry(oSolicitudCredito).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return oSolicitudCredito;

        }
        public async Task<Respuesta> EliminarSolicitudCredito(int id)
        {
            Respuesta respuesta = new Respuesta();


            var pCuenta = await _context.SolicitudCreditos.FindAsync(id);
            if (pCuenta == null)
            {
                respuesta.Message = $"No existe el SolicitudCredito {id}";
                return respuesta;
            }

            _context.SolicitudCreditos.Remove(pCuenta);
            await _context.SaveChangesAsync();
            respuesta.Message = $"El id: {id} se a eliminado correctamente";
            respuesta.IsSuccess = true;
            return respuesta;
        }

    }
}
