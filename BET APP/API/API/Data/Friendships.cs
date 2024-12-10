namespace API.Data;

public class Friendships
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FriendId { get; set; }

    public UserLogin User { get; set; }
    public UserLogin Friend { get; set; }
}