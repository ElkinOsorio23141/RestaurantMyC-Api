using System;
using System.Collections.Generic;

namespace RestaurantMyC_Api.Models;

public partial class Plato
{
    public int IdPlato { get; set; }

    public string NombrePlato { get; set; }

    public int IdCategoria { get; set; }

    public int Precio { get; set; }

    public bool Disponibilidad { get; set; }

    public virtual CategoriasPlatos? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
