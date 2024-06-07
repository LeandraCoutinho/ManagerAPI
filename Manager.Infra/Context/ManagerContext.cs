using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context;

public class ManagerContext : DbContext
{
    public ManagerContext(){}
    
    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options){}
    
     protected override void OnConfiguring(DbContextOptionsBuilder options)
     {
         var connection = "server=localhost; port=3306;database=usermanagerapi;uid=root;password=12345";
         options.UseMySql(connection, ServerVersion.AutoDetect(connection));
     }
    
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }
}