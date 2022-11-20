using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication3.Models
{
    public partial class Ef_DbFirstContext : DbContext
    {
        public Ef_DbFirstContext()
        {
        }

        public Ef_DbFirstContext(DbContextOptions<Ef_DbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Call> Call { get; set; }
        public virtual DbSet<CallOutcome> CallOutcome { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Call>(entity =>
            {
                entity.ToTable("call");

                entity.HasIndex(e => new { e.EmployeeId, e.StartTime })
                    .HasName("call_ak_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CallOutcomeId).HasColumnName("call_outcome_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CallOutcome)
                    .WithMany(p => p.Call)
                    .HasForeignKey(d => d.CallOutcomeId)
                    .HasConstraintName("call_call_outcome");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Call)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("call_customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Call)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("call_employee");
            });

            modelBuilder.Entity<CallOutcome>(entity =>
            {
                entity.ToTable("call_outcome");

                entity.HasIndex(e => e.OutcomeText)
                    .HasName("call_outcome_ak_1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OutcomeText)
                    .IsRequired()
                    .HasColumnName("outcome_text")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasColumnName("customer_address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customer_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NextCallDate)
                    .HasColumnName("next_call_date")
                    .HasColumnType("date");

                entity.Property(e => e.TsInserted)
                    .HasColumnName("ts_inserted")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
