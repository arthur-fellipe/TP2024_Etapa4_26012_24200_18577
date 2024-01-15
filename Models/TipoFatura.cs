using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class TipoFatura
{
    public int Tfid { get; set; }

    public string DescricaoTipoFatura { get; set; } = null!;

    public virtual ICollection<Fatura> Faturas { get; set; } = new List<Fatura>();
}
