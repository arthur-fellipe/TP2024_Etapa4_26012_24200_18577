using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class Utilizador
{
    public int Uid { get; set; }

    public int Nome { get; set; }

    public string Iban { get; set; } = null!;

    public string? LinkIrs { get; set; }

    public DateTime DataNascimento { get; set; }

    public int MoradaMid { get; set; }

    public int TipoUtilizadorTuid { get; set; }

    public virtual ICollection<Alojamento> Alojamentos { get; set; } = new List<Alojamento>();

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual ICollection<DocumentoUtilizador> DocumentoUtilizadors { get; set; } = new List<DocumentoUtilizador>();

    public virtual ICollection<ForumularioInicial> ForumularioInicials { get; set; } = new List<ForumularioInicial>();

    public virtual Moradum MoradaM { get; set; } = null!;

    public virtual TipoUtilizador TipoUtilizadorTu { get; set; } = null!;

    public virtual ICollection<Contacto> ContactoCos { get; set; } = new List<Contacto>();
}
