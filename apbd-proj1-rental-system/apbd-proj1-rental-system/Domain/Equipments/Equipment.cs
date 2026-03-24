namespace apbd_proj1_rental_system.Domain.Equipments;

public abstract class Equipment
{
    private static int _nextId = 1;

    protected Equipment(string name, EquipmentStatus status)
    {
        Id = _nextId++;
        Name = name;
        Status = status;
    }

    public int Id { get; }
    protected string Name { get; }
    public EquipmentStatus Status { get; set; }

    public override string ToString()
    {
        return $"{Id} | {Name} | {Status.ToDisplayString()}";
    }
}