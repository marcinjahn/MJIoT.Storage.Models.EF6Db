using System;
using System.Collections.Generic;
using System.Data.Entity;  //DbContext
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MjIot.Storage.Models.EF6Db
{
    public class MJIoTDBContext : DbContext
    {

        //connection string nazywa sie tak samo ja DbContetx, EF więc będzie od razu go rozpoznawał
        //public MJIoTDBContext()
        //    : base("name=MJIoTDBContext")
        //{

        //}

        

        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<DeviceProperty> DeviceProperties { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Connection> Connections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Device>()
            //    .HasMany(m => m.ListenerDevices)
            //    .WithMany()
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("Sender_Id");
            //        m.MapRightKey("Listener_Id");
            //        m.ToTable("DevicesConnections");
            //    });

            Database.SetInitializer<MJIoTDBContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
