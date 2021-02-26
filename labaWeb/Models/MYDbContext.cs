using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace labaWeb
{
    public partial class MYDbContext : DbContext
    {
        public MYDbContext()
        {
        }

        public MYDbContext(DbContextOptions<MYDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<BandToStyle> BandToStyles { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Concert> Concerts { get; set; }
        public virtual DbSet<ConcertAdress> ConcertAdresses { get; set; }
        public virtual DbSet<ConcertMan> ConcertMans { get; set; }
        public virtual DbSet<ConcertManToBand> ConcertManToBands { get; set; }
        public virtual DbSet<ConcertToBand> ConcertToBands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=vladm23\\cycxyzserver; Database=MYDb; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Band>(entity =>
            {
                entity.Property(e => e.BandId).HasColumnName("BandID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<BandToStyle>(entity =>
            {
                entity.ToTable("BandToStyle");

                entity.Property(e => e.BandToStyleId).HasColumnName("BandToStyleID");

                entity.Property(e => e.BandId).HasColumnName("BandID");

                entity.Property(e => e.StyleId).HasColumnName("StyleID");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.BandToStyles)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BandToSty__BandI__5CA1C101");

                entity.HasOne(d => d.Style)
                    .WithMany(p => p.BandToStyles)
                    .HasForeignKey(d => d.StyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BandToSty__Style__5BAD9CC8");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Cities__737584F6CC5B3E0C")
                    .IsUnique();

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Concert>(entity =>
            {
                entity.Property(e => e.ConcertId).HasColumnName("ConcertID");

                entity.Property(e => e.ConcertAdressId).HasColumnName("ConcertAdressID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.ConcertAdress)
                    .WithMany(p => p.Concerts)
                    .HasForeignKey(d => d.ConcertAdressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Concert__Concert__47DBAE45");
            });

            modelBuilder.Entity<ConcertAdress>(entity =>
            {
                entity.Property(e => e.ConcertAdressId).HasColumnName("ConcertAdressID");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Details).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ConcertAdresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConcertAd__CityI__55009F39");
            });

            modelBuilder.Entity<ConcertMan>(entity =>
            {
                entity.Property(e => e.ConcertManId).HasColumnName("ConcertManID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ConcertManToBand>(entity =>
            {
                entity.ToTable("ConcertManToBand");

                entity.Property(e => e.ConcertManToBandId).HasColumnName("ConcertManToBandID");

                entity.Property(e => e.BandId).HasColumnName("BandID");

                entity.Property(e => e.ConcertManId).HasColumnName("ConcertManID");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.ConcertManToBands)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConcertMa__BandI__662B2B3B");

                entity.HasOne(d => d.ConcertMan)
                    .WithMany(p => p.ConcertManToBands)
                    .HasForeignKey(d => d.ConcertManId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConcertManToBand_ConcertMans");
            });

            modelBuilder.Entity<ConcertToBand>(entity =>
            {
                entity.ToTable("ConcertToBand");

                entity.Property(e => e.ConcertToBandId).HasColumnName("ConcertToBandID");

                entity.Property(e => e.BandId).HasColumnName("BandID");

                entity.Property(e => e.ConcertId).HasColumnName("ConcertID");

                entity.HasOne(d => d.Band)
                    .WithMany(p => p.ConcertToBands)
                    .HasForeignKey(d => d.BandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ConcertTo__BandI__58D1301D");

                entity.HasOne(d => d.Concert)
                    .WithMany(p => p.ConcertToBands)
                    .HasForeignKey(d => d.ConcertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConcertToBand_Concerts");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359E1C01B298")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsFixedLength(true);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasIndex(e => e.Type, "Ck")
                    .IsUnique();

                entity.Property(e => e.StyleId).HasColumnName("StyleID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasIndex(e => e.Place, "UQ_TICKET_1")
                    .IsUnique();

                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.ConcertId).HasColumnName("ConcertID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Concert)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ConcertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Concerts");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Ticket__Customer__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
