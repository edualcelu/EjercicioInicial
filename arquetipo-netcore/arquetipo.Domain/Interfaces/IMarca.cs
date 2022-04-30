using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace arquetipo.Domain.Interfaces
{
    public interface IMarca
    {
        Task<IEnumerable<Marca>> GetMarcas();
        Task<Marca> GetMarca(int id);
        Task<Respuesta> CrearMarca(Marca oMarca);
        Task<Marca> EditarMarca(Marca oMarca);
        Task<Respuesta> EliminarMarca(int id);
    }
}
