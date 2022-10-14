using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

class BookEntityConfig : IEntityTypeConfiguration<Book>
{
    //类配置，给数据库做映射
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("T_Books");
        builder.Property(e => e.Title).HasMaxLength(50).IsRequired();
        builder.Property(e => e.AuthorName).HasMaxLength(20).IsRequired();
    }
}