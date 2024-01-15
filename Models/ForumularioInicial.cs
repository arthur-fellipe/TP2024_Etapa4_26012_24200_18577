using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class ForumularioInicial
{
    public DateTime Hora { get; set; }

    public int UtilizadorUid { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public string Localidade { get; set; } = null!;

    public float RendaMax { get; set; }

    public virtual Utilizador UtilizadorU { get; set; } = null!;

    public virtual ICollection<TipoAlojamento> TipoAlojamentoTa { get; set; } = new List<TipoAlojamento>();

    public virtual ICollection<TipoResidencium> TipoResidenciaTrs { get; set; } = new List<TipoResidencium>();
}
