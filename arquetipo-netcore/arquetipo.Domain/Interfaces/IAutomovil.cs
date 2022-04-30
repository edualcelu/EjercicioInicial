using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.Domain.Interfaces
{
    public interface IAutomovil
    {
        Task<IEnumerable<Automovil>> GetAutomoviles();
        Task<Automovil> GetAutomovil(string id);
        Task<Respuesta> CrearAutomovil(Automovil oAutomovile);
        Task<Automovil> EditarAutomovil(Automovil oAutomovile);
        Task<Respuesta> EliminarAutomovil(string id);
    }
}
