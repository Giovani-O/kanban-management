namespace API.Models
{
  public class Activity
  {
    public int Id { get; set; }
    public int BoardId { get; set; }
    public string Text { get; set; }
    public string Column { get; set; }
  }
}