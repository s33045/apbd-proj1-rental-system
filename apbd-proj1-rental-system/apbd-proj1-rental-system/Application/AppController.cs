using apbd_proj1_rental_system.Domain.Equipments;
using apbd_proj1_rental_system.Domain.Users;
using apbd_proj1_rental_system.Services;

namespace apbd_proj1_rental_system.Application;

public class AppController(UserService userService, EquipmentService equipmentService, RentalService rentalService)
{
    public void AddUser(User user)
    {
        try
        {
            userService.AddUser(user);
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
            equipmentService.AddEquipment(equipment);
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
            rentalService.AddRental(user, equipment, days);
            Console.WriteLine("Pomyślnie dodano wypożyczenie.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Nie można dodać wypożyczyczenia: {e.Message}");
        }
    }

    public void ReturnEquipment(int rentalId, bool damaged, DateTime returnDate)
    {
        try
        {
            rentalService.ReturnEquipment(rentalId, damaged, returnDate);
            Console.WriteLine("Pomyślnie zwrócono wyposażenie.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Nie można zwrócić wyposażenia: {e.Message}");
        }
    }

    public void ShowAvailableEquipments()
    {
        var equipments = equipmentService.GetAvailableEquipments();
        if (equipments.Count == 0)
        {
            Console.WriteLine("Nie znaleziono dostępnego sprzętu.");
            return;
        }

        foreach (var equipment in equipments) Console.WriteLine(equipment.ToString());
    }

    public void ShowUserActiveRentals(int userId)
    {
        var rentals = rentalService.GetUserActiveRentals(userId);
        if (rentals.Count == 0)
        {
            Console.WriteLine("Nie znaleziono aktywnych wypożyczeń dla tego użytkownika.");
            return;
        }

        foreach (var rental in rentals) Console.WriteLine(rental.ToString());
    }

    public void ShowUserAllRentals(int userId)
    {
        var rentals = rentalService.GetUserAllRentals(userId);
        if (rentals.Count == 0)
        {
            Console.WriteLine("Nie znaleziono żadnych wypożyczeń dla tego użytkownika.");
            return;
        }

        foreach (var rental in rentals) Console.WriteLine(rental.ToString());
    }

    public void ShowSummary()
    {
        var users = userService.GetAllUsers();
        var equipments = equipmentService.GetAllEquipments();
        var availableEquipments = equipmentService.GetAvailableEquipments();
        var rentals = rentalService.GetAllRentals();
        var activeRentals = rentalService.GetActiveRentals();
        var expiredRentals = rentalService.GetExpiredRentals(DateTime.Now.Date);

        Console.WriteLine("Krótkie podsumowanie danych");
        Console.WriteLine("W systemie znajduje się obecnie:");
        Console.WriteLine($"- {users.Count} użytkowników");
        Console.WriteLine($"- {equipments.Count} sprzętów, z czego {availableEquipments.Count} jest dostępnych");
        Console.WriteLine(
            $"- {rentals.Count} wypożyczeń, z czego {activeRentals.Count} jest aktywnych i {expiredRentals.Count} jest przedawnionych");
    }
}