using Microsoft.EntityFrameworkCore;
using RestaurantMyC_Api.Models;


namespace RestaurantMyC_Api.Services.Mesas
{
    public class MesaService : IMesaService
    {
        private readonly RestauratMyCContext _context;
        private readonly DbSet<Mesa> _dbSet;


        public MesaService(RestauratMyCContext context)
        {
            _context = context;
            _dbSet = _context.Set<Mesa>();
        }

        public async Task<int> Create(Mesa mesas)
        {
            await _context.Mesas.AddAsync(mesas);
            int filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas;
        }

        public async Task<int> Update(Mesa mesas)
        {
            _context.Mesas.Update(mesas);
            return await _context.SaveChangesAsync();
        }
        
        public async Task<List<Mesa>> GetAllMesas()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> Delete(int idMesa)
        {
            var Mesa = await _context.Mesas.FindAsync(idMesa);
            if (Mesa == null)
            {
                return 0;
            }

            _context.Mesas.Remove(Mesa);
            return await _context.SaveChangesAsync();
        }
    }
}
