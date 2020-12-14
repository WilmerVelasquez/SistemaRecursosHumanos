using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaRecursosHumanos.Core.Domain;

namespace SistemaRecursosHumanos.Infraestructure.Data
{
    public partial class SistemaRecursosHumanosDbContext : DbContext
    {
        public SistemaRecursosHumanosDbContext()
        {
        }

        public SistemaRecursosHumanosDbContext(DbContextOptions<SistemaRecursosHumanosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<RegistroIngreso> RegistroIngreso { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Suministro> Suministro { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("database=datos_proyecto;server=localhost;port=3306;user id=root", x => x.ServerVersion("10.4.14-mariadb"));
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClaimValue)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NormalizedName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClaimValue)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(767)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProviderKey)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProviderDisplayName)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(767)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(767)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LockoutEnd).HasColumnType("timestamp");

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NormalizedUserName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SecurityStamp)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LoginProvider)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(127)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PRIMARY");

                entity.ToTable("estado");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("Id_Estado")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreEstado)
                    .HasColumnName("Nombre_Estado")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PRIMARY");

                entity.ToTable("horario");

                entity.Property(e => e.IdHorario)
                    .HasColumnName("Id_Horario")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreHorario)
                    .HasColumnName("Nombre_Horario")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.IdSuministro)
                    .HasName("Id_Suministro");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("Id_Producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CantidadDisponible)
                    .HasColumnName("Cantidad_Disponible")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSuministro)
                    .HasColumnName("Id_Suministro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Medidas)
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NombreProducto)
                    .HasColumnName("Nombre_Producto")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdSuministroNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdSuministro)
                    .HasConstraintName("producto_ibfk_1");
            });

            modelBuilder.Entity<RegistroIngreso>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("PRIMARY");

                entity.ToTable("registro_ingreso");

                entity.HasIndex(e => e.IdHorario)
                    .HasName("Id_Horario");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("Id_Usuario");

                entity.Property(e => e.IdRegistro)
                    .HasColumnName("Id_Registro")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.HoraEntrada)
                    .HasColumnName("Hora_Entrada")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.HoraSalida)
                    .HasColumnName("Hora_Salida")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("current_timestamp()")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.IdHorario)
                    .HasColumnName("Id_Horario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreRegistro)
                    .HasColumnName("Nombre_Registro")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.RegistroIngreso)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registro_ingreso_ibfk_1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.RegistroIngreso)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registro_ingreso_ibfk_2");
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("PRIMARY");

                entity.ToTable("solicitud");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("Id_Estado");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("Id_Usuario");

                entity.Property(e => e.IdSolicitud)
                    .HasColumnName("Id_Solicitud")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaCreada)
                    .HasColumnName("Fecha_Creada")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaRespuesta)
                    .HasColumnName("Fecha_Respuesta")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("Id_Estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreSolicitud)
                    .HasColumnName("Nombre_Solicitud")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("solicitud_ibfk_1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("solicitud_ibfk_2");
            });

            modelBuilder.Entity<Suministro>(entity =>
            {
                entity.HasKey(e => e.IdSuministro)
                    .HasName("PRIMARY");

                entity.ToTable("suministro");

                entity.HasIndex(e => e.IdSolicitud)
                    .HasName("Id_Solicitud");

                entity.Property(e => e.IdSuministro)
                    .HasColumnName("Id_Suministro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSolicitud)
                    .HasColumnName("Id_Solicitud")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreSuministro)
                    .HasColumnName("Nombre_Suministro")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdSolicitudNavigation)
                    .WithMany(p => p.Suministro)
                    .HasForeignKey(d => d.IdSolicitud)
                    .HasConstraintName("suministro_ibfk_1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.AspnetusersId)
                    .HasName("Aspnetusers_Id");

                entity.HasIndex(e => e.IdEstado)
                    .HasName("Id_Estado");

                entity.HasIndex(e => e.IdHorario)
                    .HasName("Id_Horario");

                entity.HasIndex(e => e.IdSolicitud)
                    .HasName("Id_Solicitud");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_Usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AspnetusersId)
                    .HasColumnName("Aspnetusers_Id")
                    .HasColumnType("varchar(767)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Direccion)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdEstado)
                    .HasColumnName("Id_Estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdHorario)
                    .HasColumnName("Id_Horario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSolicitud)
                    .HasColumnName("Id_Solicitud")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NDocumento)
                    .HasColumnName("N_Documento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PrimerApellido)
                    .HasColumnName("Primer_Apellido")
                    .HasColumnType("varchar(14)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PrimerNombre)
                    .HasColumnName("Primer_Nombre")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("Segundo_Apellido")
                    .HasColumnType("varchar(14)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("Segundo_Nombre")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Aspnetusers)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.AspnetusersId)
                    .HasConstraintName("usuario_ibfk_5");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("usuario_ibfk_4");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdHorario)
                    .HasConstraintName("usuario_ibfk_2");

                entity.HasOne(d => d.IdSolicitudNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdSolicitud)
                    .HasConstraintName("usuario_ibfk_3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
