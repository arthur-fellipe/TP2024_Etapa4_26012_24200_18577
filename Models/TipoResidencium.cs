using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class TipoResidencium
{
    public int Trid { get; set; }

    public string Tipologia { get; set; } = null!;

    public int NumCasasBanho { get; set; }

    public virtual ICollection<Alojamento> Alojamentos { get; set; } = new List<Alojamento>();

    public virtual ICollection<ForumularioInicial> ForumularioInicials { get; set; } = new List<ForumularioInicial>();
}
