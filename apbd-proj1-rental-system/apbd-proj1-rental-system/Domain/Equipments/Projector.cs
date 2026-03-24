namespace apbd_proj1_rental_system.Domain.Equipments;

public class Projector(string name, EquipmentStatus status, string resolution, int brightnessLumens)
    : Equipment(name, status)
{
    private string Resolution { get; } = resolution;
    private int BrightnessLumens { get; } = brightnessLumens;

    public override string ToString()
    {
        return $"{Id} | {Name} | {Status.ToDisplayString()} | {Resolution} | {BrightnessLumens} lumenów";
    }
}