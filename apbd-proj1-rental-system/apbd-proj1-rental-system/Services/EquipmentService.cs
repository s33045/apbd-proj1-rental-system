using apbd_proj1_rental_system.Domain.Equipments;

namespace apbd_proj1_rental_system.Services;

public class EquipmentService
{
    private readonly List<Equipment> _equipments = new();

    public void AddEquipment(Equipment equipment)
    {
        if (_equipments.Any(e => e.Id == equipment.Id)) throw new Exception("Wyposażenie już istnieje.");

        _equipments.Add(equipment);
    }

    public Equipment GetEquipmentById(int equipmentId)
    {
        var equipment = _equipments.FirstOrDefault(e => e.Id == equipmentId);

        if (equipment == null) throw new Exception("Nie znaleziono wyposażenia.");

        return equipment;
    }

    public List<Equipment> GetAllEquipments()
    {
        return _equipments;
    }

    public List<Equipment> GetAvailableEquipments()
    {
        return _equipments.Where(e => e.Status == EquipmentStatus.Available).ToList();
    }
}