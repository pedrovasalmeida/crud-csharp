namespace UserCrud.Models;

public class User {
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Password { get; set; }
  public bool IsActive { get; set; } = true;
}
