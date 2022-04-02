using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
  public class ActivitySaveVM
  {
    public int Id { get; set; }

    [Required]
    public int BoardId { get; set; }
    
    [Required]
    public string Text { get; set; }
    
    [Required]
    public string Column { get; set; }
  }
}