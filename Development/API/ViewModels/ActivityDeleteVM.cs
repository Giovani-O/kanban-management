using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
  public class ActivityDeleteVM
  {
    [Required]
    public int ActivityId { get; set; }
  }
}