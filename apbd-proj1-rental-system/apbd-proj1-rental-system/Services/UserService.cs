using apbd_proj1_rental_system.Domain.Users;

namespace apbd_proj1_rental_system.Services;

public class UserService
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        if (_users.Any(u => u.Id == user.Id)) throw new Exception("User already exists");

        _users.Add(user);
    }

    public User GetUserById(int userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);

        if (user == null) throw new Exception("User not found");

        return user;
    }
}