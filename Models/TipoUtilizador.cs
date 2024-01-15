using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class TipoUtilizador
{
    public int Tuid { get; set; }

    public string DescricaoTipoUtilizador { get; set; } = null!;

    public virtual ICollection<Utilizador> Utilizadors { get; set; } = new List<Utilizador>();
}
