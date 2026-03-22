namespace apbd_proj1_rental_system.Domain.Users;

public abstract class User
{
    private static int _nextId = 1;

    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Id = _nextId++;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Id { get; set; }
    public abstract string UserType { get; }
}