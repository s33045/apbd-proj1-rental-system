using apbd_proj1_rental_system.Domain.Users;

namespace apbd_proj1_rental_system.Services;

public class UserService
{
    private readonly List<User> _users = [];

    public void AddUser(User user)
    {
        if (_users.Any(u => u.Id == user.Id)) throw new Exception("Użytkownik już istnieje.");

        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }
}