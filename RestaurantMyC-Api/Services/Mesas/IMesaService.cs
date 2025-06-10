using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Mesas

{
    public interface IMesaService
    {
        Task<int> Create(Mesa mesas);
        Task<int> Update(Mesa mesas);
        Task<List<Mesa>> GetAllMesas();
        Task<int> Delete(int idMesa);
    }
}
