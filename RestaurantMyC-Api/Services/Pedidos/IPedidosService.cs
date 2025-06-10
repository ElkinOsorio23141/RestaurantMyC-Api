using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Pedidos
{
    public interface IPedidosService
    {
        Task<int> Create(Pedido pedido);
        Task<int> Update(Pedido pedido);
        Task<List<Pedido>> GetAllPedidos();
        Task<int> Delete(int idpedido);
    }
}
