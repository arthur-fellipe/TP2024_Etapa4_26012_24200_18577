using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class TipoAlojamento
{
    public int Taid { get; set; }

    public string DescricaoTipoAlojamento { get; set; } = null!;

    public virtual ICollection<Alojamento> Alojamentos { get; set; } = new List<Alojamento>();

    public virtual ICollection<ForumularioInicial> ForumularioInicials { get; set; } = new List<ForumularioInicial>();
}
