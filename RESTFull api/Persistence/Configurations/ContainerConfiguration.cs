using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain;

namespace Persistence
{
  public class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.ToTable("Containers");
            builder.HasKey(x => x.Id)
                   .HasAnnotation("MySql:ValueGeneratedOnAdd", true);
        }
    }
}