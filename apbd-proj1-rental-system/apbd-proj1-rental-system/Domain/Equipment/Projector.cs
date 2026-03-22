namespace apbd_proj1_rental_system.Domain.Equipment;

public class Projector : Equipment
{
    public Projector(string name, EquipmentStatus status, string resolution, int brightnessLumens) : base(name, status)
    {
        Resolution = resolution;
        BrightnessLumens = brightnessLumens;
    }

    public string Resolution { get; set; }
    public int BrightnessLumens { get; set; }
}