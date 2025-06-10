using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Cli.Utils;
using Microsoft.EntityFrameworkCore;
using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly RestauratMyCContext _context;
        private readonly DbSet<Cliente> _dbSet;


        public ClienteService(RestauratMyCContext context)
        {
            _context = context;
            _dbSet = _context.Set<Cliente>();
        }

        public async Task<int> Create(Cliente clientes)
        {
            await _context.Clientes.AddAsync(clientes);
            int filasAfectadas = await _context.SaveChangesAsync();
            return filasAfectadas;
        }

        public async Task<int> Update(Cliente clientes)
        {
            _context.Clientes.Update(clientes);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idcliente)
        {
            var client = await _context.Clientes.FindAsync(idcliente);
            if (client == null)
            {
                return 0;
            }

            _context.Clientes.Remove(client);
            return await _context.SaveChangesAsync();
        }
    }
}
