using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class CondicoesContratuai
{
    public int Ccid { get; set; }

    public float ValorRenda { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public string DespesasInclusas { get; set; } = null!;

    public string VisitasPermitidas { get; set; } = null!;

    public float ValorCaucao { get; set; }

    public virtual ICollection<Alojamento> Alojamentos { get; set; } = new List<Alojamento>();
}
