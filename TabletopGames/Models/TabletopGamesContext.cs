using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TabletopGames.Models
{
    public partial class TabletopGamesContext : DbContext
    {
        public TabletopGamesContext(DbContextOptions<TabletopGamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TabletopGame> TabletopGame { get; set; }
        public virtual DbSet<Belongs> Belongs { get; set; }
        public virtual DbSet<Contains> Contains { get; set; }
        public virtual DbSet<GameDomain> GameDomain { get; set; }
        public virtual DbSet<GameMechanic> GameMechanic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("DbVersion", "v1.0.0");

            modelBuilder.Entity<Belongs>(entity =>
            {
                entity.HasKey(e => new { e.IdGame, e.IdDomain })
                    .HasName("PK_Belongs_1");

                entity.Property(e => e.IdGame).HasColumnName("IdGame");

                entity.Property(e => e.IdDomain).HasColumnName("IdDomain");

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany(p => p.Belongs)
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Belongs_Id_Game_2");

                entity.HasOne(d => d.IdDomainNavigation)
                    .WithMany(p => p.Belongs)
                    .HasForeignKey(d => d.IdDomain)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Belongs_Id_Domain_3");
            });

            modelBuilder.Entity<Contains>(entity =>
            {
                entity.HasKey(e => new { e.IdGame, e.IdMechanic })
                    .HasName("PK_Contains_1");

                entity.Property(e => e.IdGame).HasColumnName("IdGame");

                entity.Property(e => e.IdMechanic).HasColumnName("IdMechanic");

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany(p => p.Contains)
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contains_Id_Game_2");

                entity.HasOne(d => d.IdMechanicNavigation)
                    .WithMany(p => p.Contains)
                    .HasForeignKey(d => d.IdMechanic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mechanic_Id_Mechanic_3");
            });

            modelBuilder.Entity<GameDomain>(entity =>
            {
                entity.HasKey(e => e.IdDomain)
                    .HasName("PK__Domain__1");

                entity.Property(e => e.IdDomain)
                    .IsRequired()
                    .HasColumnName("IdDomain");

                entity.Property(e => e.NameDomain)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NameDomain");
            });

            modelBuilder.Entity<GameMechanic>(entity =>
            {
                entity.HasKey(e => e.IdMechanic)
                    .HasName("PK__Mechanic__1");

                entity.Property(e => e.IdMechanic)
                    .IsRequired()
                    .HasColumnName("IdMechanic");

                entity.Property(e => e.NameMechanic)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NameMechanic");
            });

            modelBuilder.Entity<TabletopGame>(entity =>
            {
                entity.HasKey(e => e.IdGame)
                    .HasName("PK_TabletopGame_1");

                entity.Property(e => e.IdGame)
                    .IsRequired()
                    .HasColumnName("IdGame");

                entity.Property(e => e.NameGame)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NameGame");

                entity.Property(e => e.YearGame)
                    .IsRequired()
                    .HasColumnName("YearGame");

                entity.Property(e => e.MinPlayers)
                    .IsRequired()
                    .HasColumnName("MinPlayers");

                entity.Property(e => e.MaxPlayers)
                    .IsRequired()
                    .HasColumnName("MaxPlayers");

                entity.Property(e => e.AverageRating)
                    .IsRequired()
                    .HasColumnName("AverageRating")
                    .GetType()
                    .ToString();

                entity.Property(e => e.AverageComplexity)
                    .IsRequired()
                    .HasColumnName("AverageComplexity")
                    .GetType()
                    .ToString();

                entity.Property(e => e.PlayTime)
                    .IsRequired()
                    .HasColumnName("PlayTime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
