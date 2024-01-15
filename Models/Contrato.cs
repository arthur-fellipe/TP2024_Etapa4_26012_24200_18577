using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class Contrato
{
    public int Cid { get; set; }

    public DateTime DataAssinatura { get; set; }

    public float TaxaIntermediacaoEstudante { get; set; }

    public float TaxaIntermediacaoProprietario { get; set; }

    public int UtilizadorUid { get; set; }

    public int AlojamentoAid { get; set; }

    public virtual Alojamento AlojamentoA { get; set; } = null!;

    public virtual ICollection<Fatura> Faturas { get; set; } = new List<Fatura>();

    public virtual Utilizador UtilizadorU { get; set; } = null!;
}
