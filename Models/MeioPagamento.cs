using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class MeioPagamento
{
    public int Mpid { get; set; }

    public string DescricaoMeioPagamento { get; set; } = null!;

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
