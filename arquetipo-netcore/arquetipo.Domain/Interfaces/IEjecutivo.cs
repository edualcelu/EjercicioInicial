using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<Respuesta> CargarEjecutivos();
        Task<IEnumerable<Ejecutivo>> GetEjecutivos();
        Task<Ejecutivo> GetEjecutivo(string id);
        Task<Respuesta> CrearEjecutivo(Ejecutivo oEjecutivo);
        Task<Ejecutivo> EditarEjecutivo(Ejecutivo oEjecutivo);
        Task<Respuesta> EliminarEjecutivo(string id);
    }
}
