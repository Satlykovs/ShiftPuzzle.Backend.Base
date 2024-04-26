public class CarpoolRepository : ICarpoolRepository
{
    private readonly CarpoolContext _carpoolContext;

    public CarpoolRepository(CarpoolContext carpoolContext)
    {
        _carpoolContext = carpoolContext;
    }

    public List<User> GetUsers(string origin, string destination)
    {
        return _carpoolContext.Users.Where(u => u.Origin == origin && u.Destination == destination).ToList();
    }

    public void AddUser(User user)
    {
        if (user.Name.Length < 250)
        {
            user.ID = _carpoolContext.Users.Count() + 1;
            _carpoolContext.Users.Add(user);
            _carpoolContext.SaveChanges();
        }
    }

    public void DeleteUser(int id)
    {
        User user = _carpoolContext.Users.FirstOrDefault(u => u.ID == id);
        if (user != null)
        {
            _carpoolContext.Users.Remove(user);
            _carpoolContext.SaveChanges();
        }
    }
}