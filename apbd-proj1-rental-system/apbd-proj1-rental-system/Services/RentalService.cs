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
        if (equipment.Status != EquipmentStatus.Available) throw new Exception("Equipment is not available");

        var activeRentalsCount = _rentals.Count(r => r.User.Id == user.Id && !r.IsReturned);
        if (activeRentalsCount >= user.MaxActiveRentals) throw new Exception("Maximum active rentals exceeded");

        var rental = new Rental(
            user,
            equipment,
            DateTime.Now,
            DateTime.Now.AddDays(days)
        );

        _rentals.Add(rental);
        equipment.Status = EquipmentStatus.Rented;
    }

    public void ReturnEquipment(int rentalId, bool damaged)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);

        if (rental == null)
            throw new Exception("Rental does not exist");

        if (rental.IsReturned) throw new Exception("Rental already returned");

        var returnDate = DateTime.Now.Date;
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

        rental.Return(returnDate, penalty);
    }

    public List<Rental> GetActiveRentals()
    {
        return _rentals.Where(r => r.IsActive).ToList();
    }

    public List<Rental> GetExpiredRentals()
    {
        return _rentals.Where(r => r.IsExpired(new DateTime().Date)).ToList();
    }
}