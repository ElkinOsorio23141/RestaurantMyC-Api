using System;
using System.Collections.Generic;

namespace RestaurantMyC_Api.Models;

public partial class CategoriasPlatos
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; }

    public virtual ICollection<Plato> Platos { get; } = new List<Plato>();
}
