namespace apbd_proj1_rental_system.Domain.Users;

public class Employee(string firstName, string lastName) : User(firstName, lastName)
{
    public override int MaxActiveRentals => 5;
    protected override string UserType => "Pracownik";
}