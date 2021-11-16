using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_SpMedGroup_webAPI.Domains;

#nullable disable

namespace senai_SpMedGroup_webAPI.Context
{
    public partial class SpMedGroupContext : DbContext
    {
        public SpMedGroupContext()
        {
        }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Fotoperfil> Fotoperfils { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TE4354L\\SQLEXPRESS; Initial Catalog=SP_Med_Group; user id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__CLINICA__C73A60558974C53C");

                entity.ToTable("CLINICA");

                entity.HasIndex(e => e.Telefone, "UQ__CLINICA__2A16D97FFFD87FE8")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__CLINICA__35BD3E48C830AF1D")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__CLINICA__AB6E6164F8319AD8")
                    .IsUnique();

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia")
                    .HasDefaultValueSql("('NOME FANTASIA NÃO CADASTRADO')");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefone")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__CONSULTA__CA9C61F56F0BB446");

                entity.ToTable("CONSULTA");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("datetime")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descricao")
                    .HasDefaultValueSql("('Consulta sem descrição')");

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__CONSULTA__idMedi__571DF1D5");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__CONSULTA__idPaci__5629CD9C");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__CONSULTA__idSitu__5812160E");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__ESPECIAL__40969805E70F3FB9");

                entity.ToTable("ESPECIALIDADE");

                entity.HasIndex(e => e.NomeEspecialidade, "UQ__ESPECIAL__EF876A541D016822")
                    .IsUnique();

                entity.Property(e => e.IdEspecialidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEspecialidade");

                entity.Property(e => e.NomeEspecialidade)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeEspecialidade");
            });

            modelBuilder.Entity<Fotoperfil>(entity =>
            {
                entity.HasKey(e => e.IdFotoPerfil)
                    .HasName("PK__FOTOPERF__EB73FE06F74BC8DD");

                entity.ToTable("FOTOPERFIL");

                entity.HasIndex(e => e.NomeArquivo, "UQ__FOTOPERF__3C694FC044F083F3")
                    .IsUnique();

                entity.Property(e => e.IdFotoPerfil).HasColumnName("idFotoPerfil");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeArquivo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nomeArquivo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Fotoperfils)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__FOTOPERFI__idUsu__5CD6CB2B");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__MEDICO__4E03DEBA85F9136A");

                entity.ToTable("MEDICO");

                entity.HasIndex(e => e.Crm, "UQ__MEDICO__D836F7D127932CD3")
                    .IsUnique();

                entity.Property(e => e.IdMedico).HasColumnName("idMedico");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("crm");

                entity.Property(e => e.IdClinica).HasColumnName("idClinica");

                entity.Property(e => e.IdEspecialidade).HasColumnName("idEspecialidade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomeMedico)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nomeMedico")
                    .HasDefaultValueSql("('DR NÃO CADASTRADO')");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__MEDICO__idClinic__4AB81AF0");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .HasConstraintName("FK__MEDICO__idEspeci__4BAC3F29");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__MEDICO__idUsuari__49C3F6B7");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__PACIENTE__F48A08F2860BB478");

                entity.ToTable("PACIENTE");

                entity.HasIndex(e => e.Rg, "UQ__PACIENTE__32143310EBBE4EC9")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__PACIENTE__D836E71FD154A580")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NomePaciente)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nomePaciente")
                    .HasDefaultValueSql("('NOME NÃO DECLARADO')");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rg")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("telefone")
                    .HasDefaultValueSql("('TELEFONE NÃO CADASTRADO')");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PACIENTE__idUsua__5165187F");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__SITUACAO__12AFD197DE0A6E62");

                entity.ToTable("SITUACAO");

                entity.HasIndex(e => e.NomeSituacao, "UQ__SITUACAO__E5144E4B2B418515")
                    .IsUnique();

                entity.Property(e => e.IdSituacao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacao");

                entity.Property(e => e.NomeSituacao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeSituacao");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOUSUA__03006BFFF3512BA6");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TIPOUSUA__A017BD9F4A3E803F")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A67136BC27");

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIO__idTipoU__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
