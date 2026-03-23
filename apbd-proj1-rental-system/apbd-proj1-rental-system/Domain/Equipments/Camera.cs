namespace apbd_proj1_rental_system.Domain.Equipments;

public class Camera : Equipment
{
    public Camera(string name, EquipmentStatus status, string resolution, string lensType) : base(name, status)
    {
        Resolution = resolution;
        LensType = lensType;
    }

    public string Resolution { get; set; }
    public string LensType { get; set; }

    public override string ToString()
    {
        return $"{Id} | {Name} | {Status.ToDisplayString()} | {Resolution} | {LensType}";
    }
}