namespace apbd_proj1_rental_system.Domain.Equipments;

public static class EquipmentStatusExtensions
{
    public static string ToDisplayString(this EquipmentStatus status)
    {
        return status switch
        {
            EquipmentStatus.Available => "Dostępny",
            EquipmentStatus.Rented => "Wypożyczony",
            EquipmentStatus.Damaged => "Zniszczony",
            _ => "Nieznany"
        };
    }
}