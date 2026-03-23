using apbd_proj1_rental_system.Domain.Equipments;
using apbd_proj1_rental_system.Domain.Rentals;
using apbd_proj1_rental_system.Domain.Users;

namespace apbd_proj1_rental_system.Services;

public class RentalService
{
    private const decimal PenaltyPerDay = 10m;
    private const decimal DamagePenaltyMultiplier = 1.5m;
    private readonly List<Rental> _rentals = new();

    public void AddRental(User user, Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.Available)
            throw new Exception("Wyposażenie w wypożyczeniu nie jest dostępne.");

        var activeRentalsCount = _rentals.Count(r => r.User.Id == user.Id && !r.IsReturned);
        if (activeRentalsCount >= user.MaxActiveRentals)
            throw new Exception("Maksymalna liczba aktywnych wypożyczeń została przekroczona.");

        var rental = new Rental(
            user,
            equipment,
            DateTime.Now,
            DateTime.Now.AddDays(days)
        );

        _rentals.Add(rental);
        equipment.Status = EquipmentStatus.Rented;
    }

    public void ReturnEquipment(int rentalId, bool damaged, DateTime returnDate)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);

        if (rental == null)
            throw new Exception("Nie znaleziono wypożyczenia.");

        if (rental.IsReturned) throw new Exception("Wypożyczenie zostało już zwrócone.");

        /*var returnDate = DateTime.Now.Date;*/
        var lateDays = rental.GetDelayDays(returnDate);
        var penalty = lateDays * PenaltyPerDay;

        if (damaged)
        {
            penalty *= DamagePenaltyMultiplier;
            rental.Equipment.Status = EquipmentStatus.Damaged;
        }
        else
        {
            rental.Equipment.Status = EquipmentStatus.Available;
        }

        rental.Return(returnDate.Date, penalty);
    }

    public List<Rental> GetUserActiveRentals(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && r.IsActive).ToList();
    }

    public List<Rental> GetActiveRentals()
    {
        return _rentals.Where(r => r.IsActive).ToList();
    }

    public List<Rental> GetExpiredRentals(DateTime date)
    {
        return _rentals.Where(r => r.IsExpired(date.Date)).ToList();
    }
}