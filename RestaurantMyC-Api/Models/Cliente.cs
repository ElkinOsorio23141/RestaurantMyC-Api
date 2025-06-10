using System;
using System.Collections.Generic;

namespace RestaurantMyC_Api.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string IdentificacionCliente { get; set; } = null!;

    public string NombreCliente { get; set; }

    public string ApellidosCliente { get; set; }

    public string Correo { get; set; }

    public string Telefono { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();

    public virtual ICollection<Reserva> Reservas { get; } = new List<Reserva>();
}
