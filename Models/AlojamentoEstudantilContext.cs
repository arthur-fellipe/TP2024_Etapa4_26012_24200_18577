using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TP2024_Etapa4_26012_24200_18577.Models;

public partial class AlojamentoEstudantilContext : DbContext
{
    private readonly IConfiguration _configuration;
    /*public AlojamentoEstudantilContext()
    {
    }
    private readonly IConfiguration _configuration;

    public AlojamentoEstudantilContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }*/
    public AlojamentoEstudantilContext(DbContextOptions<AlojamentoEstudantilContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alojamento> Alojamentos { get; set; }

    public virtual DbSet<CodigoPostal> CodigoPostals { get; set; }

    public virtual DbSet<CondicoesContratuai> CondicoesContratuais { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<DocumentoUtilizador> DocumentoUtilizadors { get; set; }

    public virtual DbSet<Fatura> Faturas { get; set; }

    public virtual DbSet<ForumularioInicial> ForumularioInicials { get; set; }

    public virtual DbSet<MeioPagamento> MeioPagamentos { get; set; }

    public virtual DbSet<Moradum> Morada { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<TipoAlojamento> TipoAlojamentos { get; set; }

    public virtual DbSet<TipoContacto> TipoContactos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoFatura> TipoFaturas { get; set; }

    public virtual DbSet<TipoResidencium> TipoResidencia { get; set; }

    public virtual DbSet<TipoUtilizador> TipoUtilizadors { get; set; }

    public virtual DbSet<Utilizador> Utilizadors { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AlojamentoEstudantil;Trusted_Connection=True;TrustServerCertificate=True;");*/

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            if (_configuration != null)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
            else
            {
                // Fornecer a string de conexão diretamente (exemplo hardcoded)
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AlojamentoEstudantil;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }*/


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alojamento>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__Alojamen__C6970A10EB9BD376");

            entity.ToTable("Alojamento");

            entity.Property(e => e.CondicoesContratuaisCcid).HasColumnName("CondicoesContratuaisCCid");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LinkFotos)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LinkVideos)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipoAlojamentoTaid).HasColumnName("TipoAlojamentoTAid");
            entity.Property(e => e.TipoResidenciaTrid).HasColumnName("TipoResidenciaTRid");

            entity.HasOne(d => d.CondicoesContratuaisCc).WithMany(p => p.Alojamentos)
                .HasForeignKey(d => d.CondicoesContratuaisCcid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAlojamento254622");

            entity.HasOne(d => d.MoradaM).WithMany(p => p.Alojamentos)
                .HasForeignKey(d => d.MoradaMid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAlojamento204941");

            entity.HasOne(d => d.TipoAlojamentoTa).WithMany(p => p.Alojamentos)
                .HasForeignKey(d => d.TipoAlojamentoTaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAlojamento91362");

            entity.HasOne(d => d.TipoResidenciaTr).WithMany(p => p.Alojamentos)
                .HasForeignKey(d => d.TipoResidenciaTrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAlojamento278903");

            entity.HasOne(d => d.UtilizadorU).WithMany(p => p.Alojamentos)
                .HasForeignKey(d => d.UtilizadorUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAlojamento266834");
        });

        modelBuilder.Entity<CodigoPostal>(entity =>
        {
            entity.HasKey(e => e.Cpid).HasName("PK__CodigoPo__F5B12FFEE4130C36");

            entity.ToTable("CodigoPostal");

            entity.Property(e => e.Cpid).HasColumnName("CPid");
            entity.Property(e => e.Cp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CP");
            entity.Property(e => e.Localidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CondicoesContratuai>(entity =>
        {
            entity.HasKey(e => e.Ccid).HasName("PK__Condicoe__A94F267AA1ADD341");

            entity.Property(e => e.Ccid).HasColumnName("CCid");
            entity.Property(e => e.DataFim).HasColumnType("datetime");
            entity.Property(e => e.DataInicio).HasColumnType("datetime");
            entity.Property(e => e.DespesasInclusas)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VisitasPermitidas)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.Coid).HasName("PK__Contacto__A25C32039EFB6326");

            entity.ToTable("Contacto");

            entity.HasIndex(e => e.Valor, "UQ__Contacto__07D96A1B8C6CD176").IsUnique();

            entity.Property(e => e.TipoContactoTcid).HasColumnName("TipoContactoTCid");
            entity.Property(e => e.Valor)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoContactoTc).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.TipoContactoTcid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKContacto998275");

            entity.HasMany(d => d.UtilizadorUs).WithMany(p => p.ContactoCos)
                .UsingEntity<Dictionary<string, object>>(
                    "UtilizadorContacto",
                    r => r.HasOne<Utilizador>().WithMany()
                        .HasForeignKey("UtilizadorUid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKUtilizador835380"),
                    l => l.HasOne<Contacto>().WithMany()
                        .HasForeignKey("ContactoCoid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKUtilizador699753"),
                    j =>
                    {
                        j.HasKey("ContactoCoid", "UtilizadorUid").HasName("PK__Utilizad__74236E3B782685AD");
                        j.ToTable("UtilizadorContacto");
                    });
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Contrato__C1FFD861CC98428E");

            entity.ToTable("Contrato");

            entity.Property(e => e.DataAssinatura).HasColumnType("datetime");

            entity.HasOne(d => d.AlojamentoA).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.AlojamentoAid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKContrato284166");

            entity.HasOne(d => d.UtilizadorU).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.UtilizadorUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKContrato879739");
        });

        modelBuilder.Entity<DocumentoUtilizador>(entity =>
        {
            entity.HasKey(e => e.Duid).HasName("PK__Document__2A5CEE22AB556002");

            entity.ToTable("DocumentoUtilizador");

            entity.HasIndex(e => e.NumDocumento, "UQ__Document__11150A8036FC0104").IsUnique();

            entity.Property(e => e.Duid).HasColumnName("DUid");
            entity.Property(e => e.NumDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumentoTdid).HasColumnName("TipoDocumentoTDid");

            entity.HasOne(d => d.TipoDocumentoTd).WithMany(p => p.DocumentoUtilizadors)
                .HasForeignKey(d => d.TipoDocumentoTdid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDocumentoU842694");

            entity.HasOne(d => d.UtilizadorU).WithMany(p => p.DocumentoUtilizadors)
                .HasForeignKey(d => d.UtilizadorUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDocumentoU385962");
        });

        modelBuilder.Entity<Fatura>(entity =>
        {
            entity.HasKey(e => e.Fid).HasName("PK__Fatura__C1D1314AC549B062");

            entity.ToTable("Fatura");

            entity.Property(e => e.DataFatura).HasColumnType("datetime");
            entity.Property(e => e.DataVencimento).HasColumnType("datetime");
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TipoFaturaTfid).HasColumnName("TipoFaturaTFid");

            entity.HasOne(d => d.ContratoC).WithMany(p => p.Faturas)
                .HasForeignKey(d => d.ContratoCid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFatura916361");

            entity.HasOne(d => d.TipoFaturaTf).WithMany(p => p.Faturas)
                .HasForeignKey(d => d.TipoFaturaTfid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFatura617664");
        });

        modelBuilder.Entity<ForumularioInicial>(entity =>
        {
            entity.HasKey(e => new { e.Hora, e.UtilizadorUid }).HasName("PK__Forumula__866743D853DBA914");

            entity.ToTable("ForumularioInicial");

            entity.Property(e => e.Hora).HasColumnType("datetime");
            entity.Property(e => e.DataFim).HasColumnType("datetime");
            entity.Property(e => e.DataInicio).HasColumnType("datetime");
            entity.Property(e => e.Localidade)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.UtilizadorU).WithMany(p => p.ForumularioInicials)
                .HasForeignKey(d => d.UtilizadorUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKForumulari667754");

            entity.HasMany(d => d.TipoAlojamentoTa).WithMany(p => p.ForumularioInicials)
                .UsingEntity<Dictionary<string, object>>(
                    "TipoAlojamentoForumularioInicial",
                    r => r.HasOne<TipoAlojamento>().WithMany()
                        .HasForeignKey("TipoAlojamentoTaid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKTipoAlojam978208"),
                    l => l.HasOne<ForumularioInicial>().WithMany()
                        .HasForeignKey("ForumularioInicialHora", "ForumularioInicialUtilizadorUid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKTipoAlojam280362"),
                    j =>
                    {
                        j.HasKey("ForumularioInicialHora", "ForumularioInicialUtilizadorUid", "TipoAlojamentoTaid").HasName("PK__TipoAloj__4E5C0D26ABABA775");
                        j.ToTable("TipoAlojamentoForumularioInicial");
                        j.IndexerProperty<DateTime>("ForumularioInicialHora").HasColumnType("datetime");
                        j.IndexerProperty<int>("TipoAlojamentoTaid").HasColumnName("TipoAlojamentoTAid");
                    });
        });

        modelBuilder.Entity<MeioPagamento>(entity =>
        {
            entity.HasKey(e => e.Mpid).HasName("PK__MeioPaga__6FF43AE04B7F6B0B");

            entity.ToTable("MeioPagamento");

            entity.HasIndex(e => e.DescricaoMeioPagamento, "UQ__MeioPaga__226577342BF2CF17").IsUnique();

            entity.Property(e => e.Mpid).HasColumnName("MPid");
            entity.Property(e => e.DescricaoMeioPagamento)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Moradum>(entity =>
        {
            entity.HasKey(e => e.Mid).HasName("PK__Morada__C79638C27E5E4A2C");

            entity.Property(e => e.CodigoPostalCpid).HasColumnName("CodigoPostalCPid");
            entity.Property(e => e.Complemento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rua)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoPostalCp).WithMany(p => p.Morada)
                .HasForeignKey(d => d.CodigoPostalCpid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMorada47286");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Pagament__C570593833B34414");

            entity.ToTable("Pagamento");

            entity.Property(e => e.DataPagamento).HasColumnType("datetime");
            entity.Property(e => e.MeioPagamentoMpid).HasColumnName("MeioPagamentoMPid");

            entity.HasOne(d => d.MeioPagamentoMp).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.MeioPagamentoMpid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPagamento643577");

            entity.HasMany(d => d.FaturaFs).WithMany(p => p.PagamentoPs)
                .UsingEntity<Dictionary<string, object>>(
                    "FaturaPagamento",
                    r => r.HasOne<Fatura>().WithMany()
                        .HasForeignKey("FaturaFid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKFaturaPaga995997"),
                    l => l.HasOne<Pagamento>().WithMany()
                        .HasForeignKey("PagamentoPid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKFaturaPaga139484"),
                    j =>
                    {
                        j.HasKey("PagamentoPid", "FaturaFid").HasName("PK__FaturaPa__F851FA73D0283FA7");
                        j.ToTable("FaturaPagamento");
                    });
        });

        modelBuilder.Entity<TipoAlojamento>(entity =>
        {
            entity.HasKey(e => e.Taid).HasName("PK__TipoAloj__B43CE7C2C45F9CDE");

            entity.ToTable("TipoAlojamento");

            entity.HasIndex(e => e.DescricaoTipoAlojamento, "UQ__TipoAloj__C189013008D4535A").IsUnique();

            entity.Property(e => e.Taid).HasColumnName("TAid");
            entity.Property(e => e.DescricaoTipoAlojamento)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoContacto>(entity =>
        {
            entity.HasKey(e => e.Tcid).HasName("PK__TipoCont__B7707CC70A5F4F22");

            entity.ToTable("TipoContacto");

            entity.HasIndex(e => e.DescricaoTipoContacto, "UQ__TipoCont__1CE4614E97B9FD53").IsUnique();

            entity.Property(e => e.Tcid).HasColumnName("TCid");
            entity.Property(e => e.DescricaoTipoContacto)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.Tdid).HasName("PK__TipoDocu__B73E768C5AA39B62");

            entity.ToTable("TipoDocumento");

            entity.HasIndex(e => e.DescricaoDocumento, "UQ__TipoDocu__48295F377BDF1E20").IsUnique();

            entity.Property(e => e.Tdid).HasColumnName("TDid");
        });

        modelBuilder.Entity<TipoFatura>(entity =>
        {
            entity.HasKey(e => e.Tfid).HasName("PK__TipoFatu__B7BA62FD044AAA79");

            entity.ToTable("TipoFatura");

            entity.HasIndex(e => e.DescricaoTipoFatura, "UQ__TipoFatu__02E0E79CEBC11BC1").IsUnique();

            entity.Property(e => e.Tfid).HasColumnName("TFid");
            entity.Property(e => e.DescricaoTipoFatura)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoResidencium>(entity =>
        {
            entity.HasKey(e => e.Trid).HasName("PK__TipoResi__82F89F7D194B11F1");

            entity.Property(e => e.Trid).HasColumnName("TRid");
            entity.Property(e => e.Tipologia)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.HasMany(d => d.ForumularioInicials).WithMany(p => p.TipoResidenciaTrs)
                .UsingEntity<Dictionary<string, object>>(
                    "ForumularioInicialTipoResidencium",
                    r => r.HasOne<ForumularioInicial>().WithMany()
                        .HasForeignKey("ForumularioInicialHora", "ForumularioInicialUtilizadorUid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKForumulari857719"),
                    l => l.HasOne<TipoResidencium>().WithMany()
                        .HasForeignKey("TipoResidenciaTrid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKForumulari368025"),
                    j =>
                    {
                        j.HasKey("TipoResidenciaTrid", "ForumularioInicialHora", "ForumularioInicialUtilizadorUid").HasName("PK__Forumula__D94102859BC9F822");
                        j.ToTable("ForumularioInicialTipoResidencia");
                        j.IndexerProperty<int>("TipoResidenciaTrid").HasColumnName("TipoResidenciaTRid");
                        j.IndexerProperty<DateTime>("ForumularioInicialHora").HasColumnType("datetime");
                    });
        });

        modelBuilder.Entity<TipoUtilizador>(entity =>
        {
            entity.HasKey(e => e.Tuid).HasName("PK__TipoUtil__813081967BDF68E0");

            entity.ToTable("TipoUtilizador");

            entity.HasIndex(e => e.DescricaoTipoUtilizador, "UQ__TipoUtil__E6429ECF7832E436").IsUnique();

            entity.Property(e => e.Tuid).HasColumnName("TUid");
            entity.Property(e => e.DescricaoTipoUtilizador)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__Utilizad__C5B69A4A3D7E8CC5");

            entity.ToTable("Utilizador");

            entity.Property(e => e.DataNascimento).HasColumnType("datetime");
            entity.Property(e => e.Iban)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("IBAN");
            entity.Property(e => e.LinkIrs)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LinkIRS");
            entity.Property(e => e.TipoUtilizadorTuid).HasColumnName("TipoUtilizadorTUid");

            entity.HasOne(d => d.MoradaM).WithMany(p => p.Utilizadors)
                .HasForeignKey(d => d.MoradaMid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUtilizador718967");

            entity.HasOne(d => d.TipoUtilizadorTu).WithMany(p => p.Utilizadors)
                .HasForeignKey(d => d.TipoUtilizadorTuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUtilizador68884");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
