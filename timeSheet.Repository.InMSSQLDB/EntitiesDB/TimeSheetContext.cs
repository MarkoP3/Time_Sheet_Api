using Microsoft.EntityFrameworkCore;

#nullable disable

namespace timeSheet.Repository.InMSSQLDB.EntitiesDB
{
    public partial class TimeSheetContext : DbContext
    {
        public TimeSheetContext()
        {
        }

        public TimeSheetContext(DbContextOptions<TimeSheetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Engagement> Engagements { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<SpentHour> SpentHours { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.HasIndex(e => e.Name, "UQ__clients__72E12F1BC0C29DB6")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CountryId).HasColumnName("countryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Postal)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("postal");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__clients__country__5FB337D6");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasIndex(e => e.Name, "UQ__countrie__72E12F1BFA54FAA7")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Engagement>(entity =>
            {
                entity.ToTable("engagements");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ProjectId).HasColumnName("projectID");

                entity.Property(e => e.TeamMemberId).HasColumnName("teamMemberID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Engagements)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__engagemen__proje__6D0D32F4");

                entity.HasOne(d => d.TeamMember)
                    .WithMany(p => p.Engagements)
                    .HasForeignKey(d => d.TeamMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__engagemen__teamM__6C190EBB");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("projects");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.LeadId).HasColumnName("leadID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__projects__client__66603565");

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__projects__leadID__6754599E");
            });

            modelBuilder.Entity<SpentHour>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.EngagementId })
                    .HasName("PK__spentHou__3C205979873C26FE");

                entity.ToTable("spentHours");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.EngagementId).HasColumnName("engagementID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Overtime)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("overtime");

                entity.Property(e => e.Time)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("time");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SpentHours)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__spentHour__categ__70DDC3D8");

                entity.HasOne(d => d.Engagement)
                    .WithMany(p => p.SpentHours)
                    .HasForeignKey(d => d.EngagementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__spentHour__engag__6FE99F9F");
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.ToTable("teamMembers");

                entity.HasIndex(e => e.Email, "UQ__teamMemb__AB6E6164540D7B08")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__teamMemb__F3DBC572C42785A5")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.HoursPerWeek)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("hoursPerWeek");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("salt");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
