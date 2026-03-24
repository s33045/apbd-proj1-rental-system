namespace apbd_proj1_rental_system.Domain.Users;

public class Student(string firstName, string lastName) : User(firstName, lastName)
{
    public override int MaxActiveRentals => 2;
    protected override string UserType => "Student";
}