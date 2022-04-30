using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.Domain.Interfaces
{
    public interface IAsignaCliente
    {
        Task<IEnumerable<AsignaCliente>> GetAsignaClientes();
        Task<AsignaCliente> GetAsignaCliente(string id);
        Task<Respuesta> CrearAsignaCliente(AsignaCliente oAsignaCliente);
        Task<AsignaCliente> EditarAsignaCliente(AsignaCliente oAsignaCliente);
        Task<Respuesta> EliminarAsignaCliente(string id);
    }
}
