namespace apbd_proj1_rental_system.Domain.Equipments;

public class Laptop : Equipment
{
    public Laptop(string name, EquipmentStatus status, string processor, int ramGb) : base(name, status)
    {
        Processor = processor;
        RamGb = ramGb;
    }

    public string Processor { get; set; }
    public int RamGb { get; set; }

    public override string ToString()
    {
        return $"{Id} | {Name} | {Status.ToDisplayString()} | {Processor} | {RamGb} GB";
    }
}