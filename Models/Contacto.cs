using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class Contacto
{
    public int Coid { get; set; }

    public string Valor { get; set; } = null!;

    public int TipoContactoTcid { get; set; }

    public virtual TipoContacto TipoContactoTc { get; set; } = null!;

    public virtual ICollection<Utilizador> UtilizadorUs { get; set; } = new List<Utilizador>();
}
