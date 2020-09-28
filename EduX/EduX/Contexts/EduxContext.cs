using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EduX.Domains;

namespace EduX.Contexts
{
    public partial class EduxContext : DbContext
    {
        public EduxContext()
        {
        }

        public EduxContext(DbContextOptions<EduxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlunoTurma> AlunoTurma { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Curtida> Curtida { get; set; }
        public virtual DbSet<Dica> Dica { get; set; }
        public virtual DbSet<Instituicao> Instituicao { get; set; }
        public virtual DbSet<Objetivo> Objetivo { get; set; }
        public virtual DbSet<ObjetivoAluno> ObjetivoAluno { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<ProfessorTurma> ProfessorTurma { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= EduX; User Id=sa; Password=sa132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoTurma>(entity =>
            {
                entity.HasKey(e => e.IdAlunoTurma)
                    .HasName("PK__AlunoTur__8F3223BDF943BECF");

                entity.HasIndex(e => e.IdTurma);

                entity.HasIndex(e => e.IdUsuario);

                entity.Property(e => e.IdAlunoTurma).ValueGeneratedNever();

                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.AlunoTurma)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__AlunoTurm__IdTur__4F7CD00D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AlunoTurma)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__AlunoTurm__IdUsu__4E88ABD4");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A1023BB3B1B");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D6CB9DBD19");

                entity.HasIndex(e => e.IdInstituicao);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__Curso__IdInstitu__3C69FB99");
            });

            modelBuilder.Entity<Curtida>(entity =>
            {
                entity.HasKey(e => e.IdCurtida)
                    .HasName("PK__Curtida__2169583A8C8A7FA7");

                entity.HasIndex(e => e.IdDica);

                entity.HasIndex(e => e.IdUsuario);

                entity.HasOne(d => d.IdDicaNavigation)
                    .WithMany(p => p.Curtida)
                    .HasForeignKey(d => d.IdDica)
                    .HasConstraintName("FK__Curtida__IdDica__5812160E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Curtida)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Curtida__IdUsuar__571DF1D5");
            });

            modelBuilder.Entity<Dica>(entity =>
            {
                entity.HasKey(e => e.IdDica)
                    .HasName("PK__Dica__F168851655469158");

                entity.HasIndex(e => e.IdUsuario);

                entity.Property(e => e.Imagem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Texto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Dica)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Dica__IdUsuario__47DBAE45");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__Institui__B771C0D87B018A53");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Objetivo>(entity =>
            {
                entity.HasKey(e => e.IdObjetivo)
                    .HasName("PK__Objetivo__E210F071A6858F4A");

                entity.HasIndex(e => e.IdCategoria);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Objetivo)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Objetivo__IdCate__44FF419A");
            });

            modelBuilder.Entity<ObjetivoAluno>(entity =>
            {
                entity.HasKey(e => e.IdOjetivoAluno)
                    .HasName("PK__Objetivo__07A3F088E738038F");

                entity.HasIndex(e => e.IdAlunoTurma);

                entity.HasIndex(e => e.IdObjetivo);

                entity.Property(e => e.DataAlcancado).HasColumnType("datetime");

                entity.Property(e => e.Nome).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAlunoTurmaNavigation)
                    .WithMany(p => p.ObjetivoAluno)
                    .HasForeignKey(d => d.IdAlunoTurma)
                    .HasConstraintName("FK__ObjetivoA__IdAlu__534D60F1");

                entity.HasOne(d => d.IdObjetivoNavigation)
                    .WithMany(p => p.ObjetivoAluno)
                    .HasForeignKey(d => d.IdObjetivo)
                    .HasConstraintName("FK__ObjetivoA__IdObj__5441852A");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfil__C7BD5CC16CF01EC5");

                entity.Property(e => e.IdPerfil).ValueGeneratedNever();

                entity.Property(e => e.Permissao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessorTurma>(entity =>
            {
                entity.HasKey(e => e.IdProfessorTurma)
                    .HasName("PK__Professo__D4E74F9E8C3E5288");

                entity.HasIndex(e => e.IdTurma);

                entity.HasIndex(e => e.IdUsuario);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.ProfessorTurma)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__Professor__IdTur__4BAC3F29");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ProfessorTurma)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Professor__IdUsu__4AB81AF0");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK__Turma__C1ECFFC90B321EB4");

                entity.HasIndex(e => e.IdCurso);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Turma)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Turma__IdCurso__4222D4EF");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97104F600C");

                entity.HasIndex(e => e.IdPerfil);

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.DataUltimoAcesso).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__Usuario__IdPerfi__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
