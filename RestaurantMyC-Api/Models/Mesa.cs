using System;
using System.Collections.Generic;

namespace RestaurantMyC_Api.Models;

public partial class Mesa
{
    public int IdMesa { get; set; }

    public string Ubicacion { get; set; }

    public decimal Capacidad { get; set; }

    public bool Ocupada { get; set; }

    public virtual ICollection<Reserva> Reservas { get; } = new List<Reserva>();
}
