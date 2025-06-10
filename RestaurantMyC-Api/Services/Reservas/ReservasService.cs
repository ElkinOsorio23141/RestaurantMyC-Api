using Microsoft.EntityFrameworkCore;
using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Reservas
{
    public class ReservasService : IReservasService
    {
        private readonly RestauratMyCContext _context;
        private readonly DbSet<Reserva> _dbSet;


        public ReservasService(RestauratMyCContext context)
        {
            _context = context;
            _dbSet = _context.Set<Reserva>();
        }

        public async Task<int> Create(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            int filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas;
        }

        public async Task<int> Update(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Reserva>> GetAllReservas()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> Delete(int idreserva)
        {
            var reserva = await _context.Reservas.FindAsync(idreserva);
            if (reserva == null)
            {
                return 0;
            }
            _context.Reservas.Remove(reserva);
            return await _context.SaveChangesAsync();
        }
    }
}
