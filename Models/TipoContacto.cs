using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class TipoContacto
{
    public int Tcid { get; set; }

    public string DescricaoTipoContacto { get; set; } = null!;

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}
