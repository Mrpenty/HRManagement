namespace HRManagement.Data.Entity;

public class Position
{
    public int PositionID { get; set; }
    public string PositionName { get; set; }
    public ICollection<User> Users { get; set; }
}