using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
  public class BoardSaveVM
  { 
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Subject { get; set; }

    [Required]
    public string Status { get; set; }
  }
}