using apbd_proj1_rental_system.Domain.Equipments;
using apbd_proj1_rental_system.Domain.Users;

namespace apbd_proj1_rental_system.Domain.Rentals;

public class Rental
{
    public Rental(User user, Equipment equipment, DateTime startDate, DateTime endDate)
    {
        User = user;
        Equipment = equipment;
        StartDate = startDate;
        EndDate = endDate;
        ReturnDate = null;
        Penalty = 0;
    }

    public User User { get; set; }

    public Equipment Equipment { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }

    public bool IsReturned => ReturnDate.HasValue;
    public bool HasReturnedInTime => ReturnDate >= StartDate && ReturnDate <= EndDate;
}