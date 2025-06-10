using Microsoft.EntityFrameworkCore;
using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Pedidos
{
    public class PedidosService : IPedidosService
    {
        private readonly RestauratMyCContext _context;
        private readonly DbSet<Pedido> _dbSet;


        public PedidosService(RestauratMyCContext context)
        {
            _context = context;
            _dbSet = _context.Set<Pedido>();
        }

        public async Task<int> Create(Pedido pedidos)
        {
            await _context.Pedidos.AddAsync(pedidos);
            int filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas;
        }

        public async Task<int> Update(Pedido pedidos)
        {
            _context.Pedidos.Update(pedidos);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> Delete(int idpedido)
        {
            var pedido = await _context.Pedidos.FindAsync(idpedido);
            if (pedido == null)
            {
                return 0;
            }
            _context.Pedidos.Remove(pedido);
            return await _context.SaveChangesAsync();
        }
    }
}
