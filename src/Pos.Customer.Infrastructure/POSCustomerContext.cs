using Microsoft.EntityFrameworkCore;
using Pos.Customer.Domain.CustomerAggregate;

namespace Pos.Customer.Infrastructure
{
    public partial class POSCustomerContext : DbContext
    {
        public POSCustomerContext()
        {
        }

        public POSCustomerContext(DbContextOptions<POSCustomerContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<MstCustomer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<MstCustomer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}