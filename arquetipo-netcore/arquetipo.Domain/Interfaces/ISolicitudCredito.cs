using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.Domain.Interfaces
{
    public interface ISolicitudCredito
    {
        Task<IEnumerable<SolicitudCredito>> GetSolicitudCreditos();
        Task<SolicitudCredito> GetSolicitudCredito(int id);
        Task<Respuesta> CrearSolicitudCredito(SolicitudCredito oSolicitudCredito);
        Task<SolicitudCredito> EditarSolicitudCredito(SolicitudCredito oSolicitudCredito);
        Task<Respuesta> EliminarSolicitudCredito(int id);
    }
}
