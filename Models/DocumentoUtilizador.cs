using System;
using System.Collections.Generic;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class DocumentoUtilizador
{
    public int Duid { get; set; }

    public string NumDocumento { get; set; } = null!;

    public int TipoDocumentoTdid { get; set; }

    public int UtilizadorUid { get; set; }

    public virtual TipoDocumento TipoDocumentoTd { get; set; } = null!;

    public virtual Utilizador UtilizadorU { get; set; } = null!;
}
