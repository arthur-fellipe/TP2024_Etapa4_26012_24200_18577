using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class Fatura
{
    public int Fid { get; set; }

    public DateTime DataVencimento { get; set; }

    public float ValorTotal { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime DataFatura { get; set; }

    public int TipoFaturaTfid { get; set; }

    public int ContratoCid { get; set; }

    public virtual Contrato ContratoC { get; set; } = null!;

    public virtual TipoFatura TipoFaturaTf { get; set; } = null!;

    public virtual ICollection<Pagamento> PagamentoPs { get; set; } = new List<Pagamento>();
}
