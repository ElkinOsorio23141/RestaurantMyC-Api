using Microsoft.EntityFrameworkCore;
using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Platos
{
    public class PlatosService : IPlatosService
    {
        private readonly RestauratMyCContext _context;
        private readonly DbSet<Plato> _dbSet;


        public PlatosService(RestauratMyCContext context)
        {
            _context = context;
            _dbSet = _context.Set<Plato>();
        }

        public async Task<int> Create(Plato plato)
        {
            await _context.Platos.AddAsync(plato);
            int filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas;
        }

        public async Task<int> Update(Plato plato)
        {
            _context.Platos.Update(plato);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Plato>> GetAllPlatos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> Delete(int idplato)
        {
            var plato = await _context.Platos.FindAsync(idplato);
            if (plato == null)
            {
                return 0;
            }
            _context.Platos.Remove(plato);
            return await _context.SaveChangesAsync();
        }
    }
}
