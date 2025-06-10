using System;
using System.Collections.Generic;

namespace RestaurantMyC_Api.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int IdCliente { get; set; }

    public int IdMesa { get; set; }

    public DateTime? FechaReserva { get; set; }

    public TimeSpan? HoraReserva { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Mesa? IdMesaNavigation { get; set; }
}
