using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class Moradum
{
    public int Mid { get; set; }

    public string Rua { get; set; } = null!;

    public int? NumPorta { get; set; }

    public string? Complemento { get; set; }

    public int CodigoPostalCpid { get; set; }

    public virtual ICollection<Alojamento> Alojamentos { get; set; } = new List<Alojamento>();

    public virtual CodigoPostal CodigoPostalCp { get; set; } = null!;

    public virtual ICollection<Utilizador> Utilizadors { get; set; } = new List<Utilizador>();
}
