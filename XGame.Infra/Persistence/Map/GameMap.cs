using System.Data.Entity.ModelConfiguration;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence.Map
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            ToTable("Game");

            Property(p => p.Name).HasMaxLength(100).IsRequired();
            Property(p => p.Description).HasMaxLength(255).IsRequired();
            Property(p => p.Producer).HasMaxLength(50);
            Property(p => p.Distributor).HasMaxLength(50);
            Property(p => p.Gender).HasMaxLength(50);
            Property(p => p.Site).HasMaxLength(200);

        }
    }
}
