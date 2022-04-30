using arquetipo.Domain.Interfaces;
using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using arquetipo.Repository.Context;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arquetipo.Infrastructure.Services
{
    public class EjecutivoImplementacion : IEjecutivo
    {
        private readonly BlogContext _context;
        
        private string ubicacionArchivo = "C:\\Users\\user\\Documents\\InicioBancoPichincha\\3_CodigoYBase\\ArchivoCarga\\EjecutivosArchivo.csv";


        public EjecutivoImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> CargarEjecutivos()
        {
            Respuesta respuesta = new Respuesta();
            Respuesta respuestaParcial = new Respuesta();
            int i = 0;
            string strFilasError = string.Empty;
            string strFilasOK = string.Empty;

            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
            string separador = ",";
            string linea;
            // Si el archivo no tiene encabezado, elimina la siguiente línea
            //archivo.ReadLine(); // Leer la primera línea pero descartarla porque es el encabezado
            Ejecutivo oEjecutivo = null;
            while ((linea = archivo.ReadLine()) != null)
            {
                i++;
                string[] fila = linea.Split(separador);
                bool tieneError = false;
                if (fila.Length != 11)
                {
                    tieneError = true;
                }
                else
                {
                    oEjecutivo = new Ejecutivo();
                    oEjecutivo.EIdentificacion = fila[0];
                    oEjecutivo.ENombres = fila[1];
                    oEjecutivo.EApellidos = fila[2];
                    oEjecutivo.EDireccion = fila[3];
                    oEjecutivo.ETelefonoConvencional = fila[4];
                    oEjecutivo.ECelular = fila[5];
                    oEjecutivo.ENumeroPatio = Convert.ToInt32(fila[6]);
                    oEjecutivo.EEdad = Convert.ToInt32(fila[7]);


                    try
                    {
                        respuestaParcial = await CrearEjecutivo(oEjecutivo);
                    }
                    catch (Exception e)
                    {
                        tieneError = true;
                    }

                    if (tieneError || !respuestaParcial.IsSuccess)
                    {
                        strFilasError = strFilasError + "," + i;
                    }
                    else
                    {
                        strFilasOK = strFilasOK + "," + i;
                    }

                }


            }
            respuesta.Message = $"Filas Agregados correctamente{strFilasOK} --- Filas con error {strFilasError}";
            return respuesta;
        }

        public async Task<IEnumerable<Ejecutivo>> GetEjecutivos()
        {
            return await _context.Ejecutivos.ToListAsync();
        }

        public async Task<Ejecutivo> GetEjecutivo(string id)
        {
            return await _context.Ejecutivos.FirstOrDefaultAsync(x => x.EIdentificacion == id);
        }

        public async Task<Respuesta> CrearEjecutivo(Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            Ejecutivo Ejecutivo = await GetEjecutivo(oEjecutivo.EIdentificacion);
            PatioAutoImplementacion oPatioAutoImplementacion = new PatioAutoImplementacion(_context);
            PatioAuto patioAuto = await oPatioAutoImplementacion.GetPatioAuto(oEjecutivo.ENumeroPatio);

            if (Ejecutivo != null || patioAuto == null)
            {
                respuesta.Message = $"La identificación ya esta registrada:{oEjecutivo.EIdentificacion} ";

            }
            else
            {
                _context.Ejecutivos.Add(oEjecutivo);
                respuesta.Message = $"Registrado correctamente:{oEjecutivo.EIdentificacion} ";
                respuesta.IsSuccess = true;
                await _context.SaveChangesAsync();
            }
            return respuesta;
        }

        public async Task<Ejecutivo> EditarEjecutivo(Ejecutivo oEjecutivo)
        {

            _context.Entry(oEjecutivo).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return oEjecutivo;

        }
        public async Task<Respuesta> EliminarEjecutivo(string id)
        {
            Respuesta respuesta = new Respuesta();


            var pCuenta = await _context.Ejecutivos.FindAsync(id);
            if (pCuenta == null)
            {
                respuesta.Message = $"No existe el Ejecutivo {id}";
                return respuesta;
            }

            _context.Ejecutivos.Remove(pCuenta);
            await _context.SaveChangesAsync();
            respuesta.Message = $"El id: {id} se a eliminado correctamente";
            respuesta.IsSuccess = true;
            return respuesta;
        }
    }
}
