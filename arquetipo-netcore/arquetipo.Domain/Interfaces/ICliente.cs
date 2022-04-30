using arquetipo.Entity.Dto;
using arquetipo.Entity.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace arquetipo.Domain.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> CargarClientes();
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(string id);
        Task<Respuesta> CrearCliente(Cliente oCliente);
        Task<Cliente> EditarCliente(Cliente oCliente);
        Task<Respuesta> EliminarCliente(string id);
    }
}