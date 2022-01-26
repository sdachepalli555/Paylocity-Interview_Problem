using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PCTY.DataProvider.Models
{
    public partial class PCTYContext : DbContext
    {
        private readonly string _connectionString;

        public PCTYContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDependent> EmployeeDependents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Salary).HasDefaultValueSql("((52000))");
            });

            modelBuilder.Entity<EmployeeDependent>(entity =>
            {
                entity.HasKey(e => e.DependentId);

                entity.ToTable("EmployeeDependent");

                entity.Property(e => e.DependentId).HasColumnName("DependentID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDependents)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeDependent_Employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
