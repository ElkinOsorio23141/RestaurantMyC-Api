using Microsoft.EntityFrameworkCore;
using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Categorias
{
    public class CategoriasService : ICategoriasService
    {
        private readonly RestauratMyCContext _context;
        private readonly DbSet<CategoriasPlatos> _dbSet;


        public CategoriasService(RestauratMyCContext context)
        {
            _context = context;
            _dbSet = _context.Set<CategoriasPlatos>();
        }

        public async Task<int> Create(CategoriasPlatos categoria)
        {
            await _context.CategoriasPlatos.AddAsync(categoria);
            int filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas;
        }

        public async Task<int> Update(CategoriasPlatos categoria)
        {
            _context.CategoriasPlatos.Update(categoria);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoriasPlatos>> GetAllCategorias()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> Delete(int idCategoria)
        {
            var categoria = await _context.CategoriasPlatos.FindAsync(idCategoria);
            if (categoria == null)
            {
                return 0;
            }

            _context.CategoriasPlatos.Remove(categoria);
            return await _context.SaveChangesAsync();
        }
    }
}
