namespace apbd_proj1_rental_system.Domain.Users;

public abstract class User
{
    private static int _nextId = 1;

    public User(string firstName, string lastName)
    {
        Id = _nextId++;
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int MaxActiveRentals { get; }
    public abstract string UserType { get; }

    public override string ToString()
    {
        return $"{Id} | {FirstName} | {LastName} | {UserType}";
    }
}