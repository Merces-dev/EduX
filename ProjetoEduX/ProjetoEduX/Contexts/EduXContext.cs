using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoEduX.Domains;

namespace ProjetoEduX.Contexts
{
    public partial class EduXContext : DbContext
    {
        SqlConnection con = new SqlConnection();
        public EduXContext()
        {
        }
        public EduXContext(DbContextOptions<EduXContext> options)
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
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=edux;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoTurma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK__AlunoTur__8F3223BD01378F08");

                entity.Property(e => e.IdTurma).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.AlunoTurma)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__AlunoTurm__IdTur__534D60F1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.AlunoTurma)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__AlunoTurm__IdUsu__5441852A");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A106368F77B");

                entity.Property(e => e.IdCategoria).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D61FC59631");

                entity.Property(e => e.IdCurso).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__Curso__IdInstitu__3E52440B");
            });

            modelBuilder.Entity<Curtida>(entity =>
            {
                entity.HasKey(e => e.IdCurtida)
                    .HasName("PK__Curtida__2169583AEDE3FFC4");

                entity.Property(e => e.IdCurtida).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.IdDicaNavigation)
                    .WithMany(p => p.Curtida)
                    .HasForeignKey(d => d.IdDica)
                    .HasConstraintName("FK__Curtida__IdDica__6754599E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Curtida)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Curtida__IdUsuar__66603565");
            });

            modelBuilder.Entity<Dica>(entity =>
            {
                entity.HasKey(e => e.IdDica)
                    .HasName("PK__Dica__F1688516165E073F");

                entity.Property(e => e.IdDica).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Texto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Dica)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Dica__IdUsuario__628FA481");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao)
                    .HasName("PK__Institui__B771C0D8300BB474");

                entity.Property(e => e.IdInstituicao).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
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
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
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
                    .HasName("PK__Objetivo__E210F07101E1EFB0");

                entity.Property(e => e.IdObjetivo).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Objetivo)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Objetivo__IdCate__47DBAE45");
            });

            modelBuilder.Entity<ObjetivoAluno>(entity =>
            {
                entity.HasKey(e => e.IdObjetivoAluno)
                    .HasName("PK__Objetivo__81E21D7A3C22EC33");

                entity.Property(e => e.IdObjetivoAluno).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DataAlcancado).HasColumnType("datetime");

                entity.Property(e => e.Nota).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdAlunoTurmaNavigation)
                    .WithMany(p => p.ObjetivoAluno)
                    .HasForeignKey(d => d.IdAlunoTurma)
                    .HasConstraintName("FK__ObjetivoA__IdAlu__59063A47");

                entity.HasOne(d => d.IdObjetivoNavigation)
                    .WithMany(p => p.ObjetivoAluno)
                    .HasForeignKey(d => d.IdObjetivo)
                    .HasConstraintName("FK__ObjetivoA__IdObj__59FA5E80");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfil__C7BD5CC144A3159B");

                entity.Property(e => e.IdPerfil).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Permissao)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfessorTurma>(entity =>
            {
                entity.HasKey(e => e.IdProfessorUsuario)
                    .HasName("PK__Professo__FB66BF80B207C784");

                entity.Property(e => e.IdProfessorUsuario).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.ProfessorTurma)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK__Professor__IdTur__5EBF139D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ProfessorTurma)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Professor__IdUsu__5DCAEF64");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK__Turma__C1ECFFC9389E7C67");

                entity.Property(e => e.IdTurma).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Turma)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Turma__IdCurso__4BAC3F29");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF972A7E58E7");

                entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");

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
                    .HasConstraintName("FK__Usuario__IdPerfi__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
