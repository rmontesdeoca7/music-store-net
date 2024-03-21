using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.DataAccess.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder
               .Property(p => p.Name)
               .HasMaxLength(150);
            builder.HasData(new List<Gender>
            {
                new Gender() { Id=1, Name = "Rock" },
                new Gender() { Id=2, Name = "Pop" },
                new Gender() { Id=3, Name = "Jazz" },
                new Gender() { Id=4, Name = "Metal" },
                new Gender() { Id=5, Name = "Disco" },
                new Gender() { Id=6, Name = "Blues" },
                new Gender() { Id=7, Name = "Reggae" },
                new Gender() { Id=8, Name = "Fusion" },
                new Gender() { Id=9, Name = "Merenge" },
                new Gender() { Id=10, Name = "Salsa" }

            });
        }
    }
}
