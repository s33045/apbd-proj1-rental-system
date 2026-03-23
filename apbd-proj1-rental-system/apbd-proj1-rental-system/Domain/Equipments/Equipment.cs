namespace apbd_proj1_rental_system.Domain.Equipments;

public class Equipment
{
    private static int _nextId = 1;

    public Equipment(string name, EquipmentStatus status)
    {
        Id = _nextId++;
        Name = name;
        Status = status;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public EquipmentStatus Status { get; set; }

    public override string ToString()
    {
        return $"{Id} | {Name} | {Status.ToDisplayString()}";
    }
}