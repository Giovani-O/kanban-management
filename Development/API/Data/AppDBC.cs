using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
  public class AppDBC : DbContext
  {
    /// <summary> 
    /// Inicia a tabela Activities
    /// <summary/>
    public DbSet<Activity> Activities { get; set; }

    /// <summary
    /// Inicia a tabela Boards
    /// <summary/>
    public DbSet<Board> Boards { get; set; }

    protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder) 
      => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
  }
}