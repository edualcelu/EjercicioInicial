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
    public class ClienteImplementacion : ICliente
    {
        private readonly BlogContext _context;
        private string ubicacionArchivo = "C:\\Users\\user\\Documents\\InicioBancoPichincha\\3_CodigoYBase\\ArchivoCarga\\ClientesArchivo.csv";

        public enum EstadoCivil
        {
            Soltero = 'S',
            Casado = 'C',
            Divorciado = 'D',
        }

        public ClienteImplementacion(BlogContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> CargarClientes()
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
            Cliente oCliente = null;
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
                    oCliente = new Cliente();
                    oCliente.ClIdentificacion = fila[0];
                    oCliente.ClNombres = fila[1];
                    oCliente.ClEdad = Convert.ToInt32(fila[2]);
                    oCliente.ClFechaNacimiento = Convert.ToDateTime(fila[3]);
                    oCliente.ClApellidos = fila[4];
                    oCliente.ClDireccion = fila[5];
                    oCliente.ClTelefono = fila[6];
                    oCliente.ClEstadoCivil = fila[7];
                    oCliente.ClIdentificacionConyuge = fila[8];
                    oCliente.ClNombreConyuge = fila[9];
                    oCliente.ClSujetoCredito = Convert.ToBoolean(Convert.ToInt16(fila[10]));
                    try
                    {
                        respuestaParcial = await CrearCliente(oCliente);
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

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetCliente(string id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.ClIdentificacion == id);
        }

        public async Task<Respuesta> CrearCliente(Cliente oCliente)
        {
            Respuesta respuesta = new Respuesta();
            Cliente cliente = await GetCliente(oCliente.ClIdentificacion);
            if (cliente != null)
            {
                respuesta.Message = $"La identificación ya esta registrada:{oCliente.ClIdentificacion} ";
                
            }
            else 
            {
                _context.Clientes.Add(oCliente);
                respuesta.Message = $"Registrado correctamente:{oCliente.ClIdentificacion} ";
                respuesta.IsSuccess = true;
                await _context.SaveChangesAsync();
            }
            return respuesta;
        }

        public async Task<Cliente> EditarCliente(Cliente oCliente)
        {

            _context.Entry(oCliente).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return oCliente;
           
        }
        public async Task<Respuesta> EliminarCliente(string id)
        {
            Respuesta respuesta = new Respuesta();

            
            var pCuenta = await _context.Clientes.FindAsync(id);
            if (pCuenta == null)
            {
                respuesta.Message = $"No existe el cliente {id}";
                return respuesta;
            }

            _context.Clientes.Remove(pCuenta);
            await _context.SaveChangesAsync();
            respuesta.Message = $"El id: {id} se a eliminado correctamente";
            respuesta.IsSuccess = true;
            return respuesta;
        }

    }
}