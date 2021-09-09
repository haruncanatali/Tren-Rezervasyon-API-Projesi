using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Concrete;

namespace TrainReservation.Entities.Mapping
{
    public class TrainMap : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.TrainName).IsRequired().HasMaxLength(100);

            builder.ToTable("Tbl_Train");
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.TrainName).HasColumnName("TrainName");
        }
    }
}
