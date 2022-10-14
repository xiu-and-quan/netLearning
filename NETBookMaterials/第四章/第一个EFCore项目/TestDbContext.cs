using Microsoft.EntityFrameworkCore;
class TestDbContext : DbContext
{
    //上下文配置 数据源配置以及设置读取类配置包
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connStr = "server=.;database=TestBase;uid=sa;pwd=root";
        optionsBuilder.UseSqlServer(connStr);
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}