﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence.Map
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable("Player");

            Property(p => p.Email.Address).HasMaxLength(200).IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_PLAYER_EMAIL") { IsUnique = true }))
                .HasColumnName("Email");
            Property(p => p.Name.FirstName).HasMaxLength(50).IsRequired().HasColumnName("FirstName");
            Property(p => p.Name.LastName).HasMaxLength(50).IsRequired().HasColumnName("LastName");
            Property(p => p.Password).IsRequired();
            Property(p => p.Status).IsRequired();
        }
    }
}
