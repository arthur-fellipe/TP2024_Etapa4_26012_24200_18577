using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class TipoDocumento
{
    public int Tdid { get; set; }

    public int DescricaoDocumento { get; set; }

    public virtual ICollection<DocumentoUtilizador> DocumentoUtilizadors { get; set; } = new List<DocumentoUtilizador>();
}
