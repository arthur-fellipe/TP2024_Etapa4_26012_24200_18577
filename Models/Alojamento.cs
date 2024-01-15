using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class Alojamento
{
    public int Aid { get; set; }

    public string? Descricao { get; set; }

    public string? LinkFotos { get; set; }

    public string? LinkVideos { get; set; }

    public int MoradaMid { get; set; }

    public int CondicoesContratuaisCcid { get; set; }

    public int TipoAlojamentoTaid { get; set; }

    public int TipoResidenciaTrid { get; set; }

    public int UtilizadorUid { get; set; }

    public virtual CondicoesContratuai CondicoesContratuaisCc { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual Moradum MoradaM { get; set; } = null!;

    public virtual TipoAlojamento TipoAlojamentoTa { get; set; } = null!;

    public virtual TipoResidencium TipoResidenciaTr { get; set; } = null!;

    public virtual Utilizador UtilizadorU { get; set; } = null!;
}
