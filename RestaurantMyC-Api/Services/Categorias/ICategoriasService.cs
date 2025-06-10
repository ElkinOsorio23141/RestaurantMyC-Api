using RestaurantMyC_Api.Models;

namespace RestaurantMyC_Api.Services.Categorias
{
    public interface ICategoriasService
    {
        Task<int> Create(CategoriasPlatos categorias);
        Task<int> Update(CategoriasPlatos categorias);
        Task<List<CategoriasPlatos>> GetAllCategorias();
        Task<int> Delete(int idCategoria);
    }
}
