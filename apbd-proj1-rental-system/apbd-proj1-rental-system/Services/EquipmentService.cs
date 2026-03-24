using apbd_proj1_rental_system.Domain.Equipments;

namespace apbd_proj1_rental_system.Services;

public class EquipmentService
{
    private readonly List<Equipment> _equipments = [];

    public void AddEquipment(Equipment equipment)
    {
        if (_equipments.Any(e => e.Id == equipment.Id)) throw new Exception("Wyposażenie już istnieje.");

        _equipments.Add(equipment);
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