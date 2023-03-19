using Microsoft.EntityFrameworkCore;
using Pvms.DAL.Entities;

namespace Pvms.DAL;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        
    }
    public DbSet<SpecializationInfo> SpecializationInfos { get; set; }
    public DbSet<UserStatistics> UserStatistics { get; set; }
}