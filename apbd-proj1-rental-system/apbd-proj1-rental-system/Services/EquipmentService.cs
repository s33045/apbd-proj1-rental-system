using apbd_proj1_rental_system.Domain.Equipments;

namespace apbd_proj1_rental_system.Services;

public class EquipmentService
{
    private readonly List<Equipment> _equipments = new();

    public void AddEquipment(Equipment equipment)
    {
        if (_equipments.Any(e => e.Id == equipment.Id)) throw new Exception("Equipment already exists");

        _equipments.Add(equipment);
    }

    public Equipment GetEquipmentById(int equipmentId)
    {
        var equipment = _equipments.FirstOrDefault(e => e.Id == equipmentId);

        if (equipment == null) throw new Exception("Equipment not found");

        return equipment;
    }

    public void ListAllEquipments()
    {
        if (_equipments.Count == 0)
        {
            Console.WriteLine("Brak zarejestrowanego wyposażenia.");
            return;
        }

        foreach (var equipment in _equipments) Console.WriteLine(equipment.ToString());
    }

    public void ListAvailableEquipments()
    {
        var availableEquipments = _equipments.Where(e => e.Status == EquipmentStatus.Available).ToList();

        if (availableEquipments.Count == 0)
        {
            Console.WriteLine("Brak wyposażenia dostępnego do wypożyczenia.");
            return;
        }

        foreach (var equipment in availableEquipments) Console.WriteLine(equipment.ToString());
    }
}