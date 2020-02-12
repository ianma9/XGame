using System.Data.Entity;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameDataContext : DbContext
    {
        public XGameDataContext() : base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Setar para usar varchar ou invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            #region Adiciona entidades mapeadas - Automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameDataContext).Assembly);
            #endregion


            base.OnModelCreating(modelBuilder);

        }

    }
}
