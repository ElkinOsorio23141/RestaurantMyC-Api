using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Reservas
{
    public interface IReservasService
    {
        Task<int> Create(Reserva reserva);
        Task<int> Update(Reserva reserva);
        Task<List<Reserva>> GetAllReservas();
        Task<int> Delete(int idreserva);
    }
}
