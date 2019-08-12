using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Chassis)
                .IsRequired()
                .HasColumnName("Chassis");

            builder.Property(e => e.Color)
                .IsRequired()
                .HasColumnName("Color");

            builder.Property(e => e.Type)
                .IsRequired()
                .HasColumnName("Type");

            builder.Property(e => e.PassengerCapacity)
                .HasColumnName("PassengerCapacity");

            builder.HasIndex(e => e.Chassis)
                .IsUnique();

            builder.Property(e => e.DateCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}