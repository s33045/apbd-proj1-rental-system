using apbd_proj1_rental_system.Domain.Equipments;
using apbd_proj1_rental_system.Domain.Users;

namespace apbd_proj1_rental_system.Domain.Rentals;

public class Rental
{
    private static int _nextId = 1;

    public Rental(User user, Equipment equipment, DateTime startDate, DateTime endDate)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(equipment);

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

    public int Id { get; }
    public User User { get; }
    public Equipment Equipment { get; }
    private DateTime StartDate { get; }
    private DateTime EndDate { get; }
    private DateTime? ReturnDate { get; set; }
    private decimal Penalty { get; set; }


    public bool IsReturned => ReturnDate.HasValue;
    public bool IsActive => !IsReturned;

    public bool IsExpired(DateTime today)
    {
        return !IsReturned && today.Date > EndDate.Date;
    }

    public int GetDelayDays(DateTime returnDate)
    {
        return returnDate.Date <= EndDate.Date ? 0 : (returnDate.Date - EndDate.Date).Days;
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

    public override string ToString()
    {
        var returnedText = IsReturned ? $"Zwrócono {ReturnDate}" : "Nie zwrócono";
        var penaltyText = $"Kara {Penalty}";
        return $"{Id} | ({User}) | {Equipment} | {StartDate.Date} - {EndDate.Date} | {returnedText} | {penaltyText}";
    }
}