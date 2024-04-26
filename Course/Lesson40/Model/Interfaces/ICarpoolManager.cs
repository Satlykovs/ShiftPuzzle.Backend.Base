public interface ICarpoolManager
{

    public void AddUser(User user);

    public void DeleteUser(int id);

    public List<User> GetUsers(string origin, string destination);

}