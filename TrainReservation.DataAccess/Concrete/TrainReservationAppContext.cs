using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainReservation.Entities.Concrete;
using TrainReservation.Entities.Mapping;

namespace TrainReservation.DataAccess.Concrete
{
    public class TrainReservationAppContext:DbContext
    {

        private readonly string connectionString = "Server=DESKTOP-SL1S3RQ\\SQLEXPRESS;Database=DboTrainReservationProject;Trusted_Connection=True;MultipleActiveResultSets=true";

        public TrainReservationAppContext(DbContextOptions<TrainReservationAppContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


        public DbSet<Train> Tbl_Train { get; set; }
        public DbSet<Vagon> Tbl_Vagon { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Train>().HasMany(c => c.Vagons).WithOne(c => c.Train).HasForeignKey(c => c.TrainId);

            builder.ApplyConfiguration(new TrainMap());
            builder.ApplyConfiguration(new VagonMap());
        }
    }
}
