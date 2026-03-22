namespace apbd_proj1_rental_system.Domain.Equipment;

public class Equipment
{
    private static int _nextId = 1;

    public Equipment(string name, EquipmentStatus status)
    {
        Name = name;
        Status = status;
        Id = _nextId++;
    }

    public string Name { get; set; }
    public EquipmentStatus Status { get; set; }
    private int Id { get; set; }
}