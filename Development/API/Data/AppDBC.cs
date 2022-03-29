using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
  public class AppDBC : DbContext
  {
    public DbSet<Activity> Activities { get; set; }
  }
}