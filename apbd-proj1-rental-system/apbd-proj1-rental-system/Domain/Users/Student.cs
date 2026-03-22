namespace apbd_proj1_rental_system.Domain.Users;

public class Student : User
{
    public Student(string firstName, string lastName) : base(firstName, lastName)
    {
    }

    public override string UserType => "Student";
}