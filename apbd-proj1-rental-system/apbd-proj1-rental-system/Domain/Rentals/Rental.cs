using apbd_proj1_rental_system.Domain.Equipments;
using apbd_proj1_rental_system.Domain.Users;

namespace apbd_proj1_rental_system.Domain.Rentals;

public class Rental
{
    private static int _nextId = 1;

    public Rental(User user, Equipment equipment, DateTime startDate, DateTime endDate)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (equipment == null) throw new ArgumentNullException(nameof(equipment));
        if (endDate < startDate)
            throw new ArgumentException("Data zakończenia musi być późniejsza niż data rozpoczęcia.");

        Id = _nextId++;
        User = user;
        Equipment = equipment;
        StartDate = startDate;
        EndDate = endDate;
        ReturnDate = null;
        Penalty = 0;
    }

    public int Id { get; set; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }


    public bool IsReturned => ReturnDate.HasValue;
    public bool IsActive => !IsReturned;
    public bool HasReturnedInTime => IsReturned && ReturnDate.Value.Date <= EndDate.Date;

    public bool IsExpired(DateTime today)
    {
        return !IsReturned && today.Date > EndDate.Date;
    }

    public int GetDelayDays(DateTime returnDate)
    {
        if (returnDate.Date <= EndDate.Date) return 0;
        return (returnDate.Date - EndDate.Date).Days;
    }

    public void Return(DateTime returnDate, decimal penalty)
    {
        if (IsReturned) throw new Exception("Wypożyczenie zostało już zwrócone.");
        if (returnDate.Date < StartDate.Date)
            throw new Exception("Data zwrotu musi być późniejsza niż data rozpoczęcia");
        if (penalty < 0) throw new Exception("Wartość karty nie może być ujemna.");

        ReturnDate = returnDate.Date;
        Penalty = penalty;
    }
}