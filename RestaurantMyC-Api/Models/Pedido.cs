using System;
using System.Collections.Generic;

namespace RestaurantMyC_Api.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public string NumeroPedido { get; set; }

    public int IdCliente { get; set; }

    public int IdPlato { get; set; }

    public DateTime FechaPedido { get; set; }

    public int Cantidad { get; set; }

    public int ValorTotal { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Plato IdPlatoNavigation { get; set; } = null!;
}
