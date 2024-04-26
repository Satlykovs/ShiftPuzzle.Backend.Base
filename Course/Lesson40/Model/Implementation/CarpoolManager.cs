public class CarpoolManager : ICarpoolManager
{
    private ICarpoolRepository _carpoolRepository;
    
    public CarpoolManager(ICarpoolRepository carpoolRepository)
    {
        _carpoolRepository = carpoolRepository;
    }

    public void AddUser(User user)
    {
        _carpoolRepository.AddUser(user);
    }
    public void DeleteUser(int id)
    {
        _carpoolRepository.DeleteUser(id);
    }
    public List<User> GetUsers(string origin, string destination)
    {
        return _carpoolRepository.GetUsers(origin, destination);
    }
}