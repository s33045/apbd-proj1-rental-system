namespace apbd_proj1_rental_system.Domain.Users;

public class Employee : User
{
    public Employee(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override int MaxActiveRentals => 5;
    public override string UserType => "Employee";
}