using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Clientes
{
    public interface IClienteService
    {
        Task<int> Create(Cliente clientes);
        Task<int> Update(Cliente clientes);
        Task<int> Delete(int idcliente);
    }
}
