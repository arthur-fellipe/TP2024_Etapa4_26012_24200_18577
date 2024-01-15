using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class CodigoPostal
{
    public int Cpid { get; set; }

    public string Cp { get; set; } = null!;

    public string Localidade { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ICollection<Moradum> Morada { get; set; } = new List<Moradum>();
}
