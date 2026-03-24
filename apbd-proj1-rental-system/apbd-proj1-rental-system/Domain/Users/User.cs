namespace apbd_proj1_rental_system.Domain.Users;

public abstract class User
{
    private static int _nextId = 1;

    protected User(string firstName, string lastName)
    {
        Id = _nextId++;
        FirstName = firstName;
        LastName = lastName;
    }

    public int Id { get; }
    private string FirstName { get; }
    private string LastName { get; }
    public abstract int MaxActiveRentals { get; }
    protected abstract string UserType { get; }

    public override string ToString()
    {
        return $"{Id} | {FirstName} | {LastName} | {UserType}";
    }
}