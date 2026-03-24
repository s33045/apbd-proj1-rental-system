namespace apbd_proj1_rental_system.Domain.Equipments;

public class Camera(string name, EquipmentStatus status, string resolution, string lensType)
    : Equipment(name, status)
{
    private string Resolution { get; } = resolution;
    private string LensType { get; } = lensType;

    public override string ToString()
    {
        return $"{Id} | {Name} | {Status.ToDisplayString()} | {Resolution} | {LensType}";
    }
}