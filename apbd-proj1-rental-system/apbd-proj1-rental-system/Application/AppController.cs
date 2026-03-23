using apbd_proj1_rental_system.Domain.Equipments;
using apbd_proj1_rental_system.Domain.Users;
using apbd_proj1_rental_system.Services;

namespace apbd_proj1_rental_system.Application;

public class AppController
{
    public readonly EquipmentService _equipmentService;
    public readonly RentalService _rentalService;
    public readonly UserService _userService;

    public AppController(UserService userService, EquipmentService equipmentService, RentalService rentalService)
    {
        _userService = userService;
        _equipmentService = equipmentService;
        _rentalService = rentalService;
    }

    public void AddUser(User user)
    {
        try
        {
            _userService.AddUser(user);
            Console.WriteLine("Pomyślnie dodano użytkownika.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Nie można dodać użytkownika: {e.Message}");
        }
    }

    public void AddEquipment(Equipment equipment)
    {
        try
        {
            _equipmentService.AddEquipment(equipment);
            Console.WriteLine("Pomyślnie dodano wyposażenie.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Nie można dodać wyposażenia: {e.Message}");
        }
    }

    public void AddRental(User user, Equipment equipment, int days)
    {
        try
        {
            _rentalService.AddRental(user, equipment, days);
            Console.WriteLine("Pomyślnie dodano wypożyczenie.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Nie można dodać wypożyczyczenia: {e.Message}");
        }
    }

    public void ReturnEquipment(int rentalId, bool damaged)
    {
        try
        {
            _rentalService.ReturnEquipment(rentalId, damaged);
            Console.WriteLine("Pomyślnie zwrócono wyposażenie.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Nie można zwrócić wyposażenia: {e.Message}");
        }
    }

    public void ShowAllEquipments()
    {
        var equipments = _equipmentService.GetAllEquipments();
        if (equipments.Count == 0)
        {
            Console.WriteLine("Nie znaleziono żadnego sprzętu.");
            return;
        }

        foreach (var equipment in equipments) Console.WriteLine(equipment.ToString());
    }

    public void ShowAvailableEquipments()
    {
        var equipments = _equipmentService.GetAvailableEquipments();
        if (equipments.Count == 0)
        {
            Console.WriteLine("Nie znaleziono dostępnego sprzętu.");
            return;
        }

        foreach (var equipment in equipments) Console.WriteLine(equipment.ToString());
    }

    public void ShowUserActiveRentals(int userId)
    {
        var rentals = _rentalService.GetUserActiveRentals(userId);
        if (rentals.Count == 0) Console.WriteLine("Nie znaleziono aktywnych wypożyczeń dla tego użytkownika.");
    }

    public void ShowActiveRentals()
    {
        var rentals = _rentalService.GetActiveRentals();
        if (rentals.Count == 0)
        {
            Console.WriteLine("Nie znaleziono aktywnych wypożyczeń.");
            return;
        }

        foreach (var rental in rentals) Console.WriteLine(rental.ToString());
    }

    public void ShowExpiredRentals()
    {
        var rentals = _rentalService.GetExpiredRentals();
        if (rentals.Count == 0)
        {
            Console.WriteLine("Nie znaleziono przedawnionych wypożyczeń.");
            return;
        }

        foreach (var rental in rentals) Console.WriteLine(rental.ToString());
    }
}