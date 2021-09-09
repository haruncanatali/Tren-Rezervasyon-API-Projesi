using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.Entities.Mapping
{
    public class VagonMap : IEntityTypeConfiguration<Vagon>
    {
        public void Configure(EntityTypeBuilder<Vagon> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.VagonName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Capacity).IsRequired();
            builder.Property(c => c.NumberOfFullSeat).IsRequired().HasDefaultValue(0);
            builder.Property(c => c.TrainId).IsRequired();

            builder.ToTable("Tbl_Vagon");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.VagonName).HasColumnName("VagonName");
            builder.Property(c => c.Capacity).HasColumnName("Capacity");
            builder.Property(c => c.NumberOfFullSeat).HasColumnName("NumberOfFullSeat");
            builder.Property(c => c.TrainId).HasColumnName("TrainId");
        }
    }
}
