using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class Pagamento
{
    public int Pid { get; set; }

    public DateTime DataPagamento { get; set; }

    public int MeioPagamentoMpid { get; set; }

    public virtual MeioPagamento MeioPagamentoMp { get; set; } = null!;

    public virtual ICollection<Fatura> FaturaFs { get; set; } = new List<Fatura>();
}
