using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Platos
{
    public interface IPlatosService
    {
        Task<int> Create(Plato plato);
        Task<int> Update(Plato peplatodido);
        Task<List<Plato>> GetAllPlatos();
        Task<int> Delete(int idplato);
    }
}
