namespace apbd_proj1_rental_system.Domain.Equipments;

public class Laptop(string name, EquipmentStatus status, string processor, int ramGb)
    : Equipment(name, status)
{
    private string Processor { get; } = processor;
    private int RamGb { get; } = ramGb;

    public override string ToString()
    {
        return $"{Id} | {Name} | {Status.ToDisplayString()} | {Processor} | {RamGb} GB";
    }
}