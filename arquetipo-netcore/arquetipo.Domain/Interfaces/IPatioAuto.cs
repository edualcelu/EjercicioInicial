using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.Domain.Interfaces
{
    public interface IPatioAuto
    {
        Task<IEnumerable<PatioAuto>> GetPatioAutos();
        Task<PatioAuto> GetPatioAuto(int id);
        Task<Respuesta> CrearPatioAuto(PatioAuto oPatioAuto);
        Task<PatioAuto> EditarPatioAuto(PatioAuto oPatioAuto);
        Task<Respuesta> EliminarPatioAuto(int id);
    }
}
