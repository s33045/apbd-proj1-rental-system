using apbd_proj1_rental_system.Application;
using apbd_proj1_rental_system.Domain.Equipments;
using apbd_proj1_rental_system.Domain.Users;
using apbd_proj1_rental_system.Services;

var userService = new UserService();
var equipmentService = new EquipmentService();
var rentalService = new RentalService();

var app = new AppController(userService, equipmentService, rentalService);

var student = new Student("Jan", "Kowalski");
var employee = new Employee("Anna", "Nowak");

var laptop1 = new Laptop("Dell Extra 7420", EquipmentStatus.Available, "i5-10400F", 16);
var laptop2 = new Laptop("Dell Super 4150", EquipmentStatus.Available, "i9-9900KF", 16);
var camera1 = new Camera("Sony 250D", EquipmentStatus.Available, "24 MP", "18-55mm");
var camera2 = new Camera("Canon 100B", EquipmentStatus.Available, "24 MP", "16-35mm");
var projector = new Projector("Epson EB-X06", EquipmentStatus.Available, "1024x768", 3600);

Console.WriteLine("===== Dodawanie użytkowników =====");
app.AddUser(student);
app.AddUser(employee);

Console.WriteLine("\n===== Dodawanie sprzętu =====");
app.AddEquipment(laptop1);
app.AddEquipment(laptop2);
app.AddEquipment(camera1);
app.AddEquipment(camera2);
app.AddEquipment(projector);

Console.WriteLine("\n===== Cały sprzęt =====");
app.ShowAvailableEquipments();

Console.WriteLine("\n===== Dostępny sprzęt =====");
app.ShowAvailableEquipments();

Console.WriteLine("\n===== Poprawne wypożyczenie =====");
app.AddRental(employee, laptop1, 1);

Console.WriteLine("\n===== Próba przekroczenia limitu wypożyczeń =====");
app.AddRental(student, camera1, 1);
app.AddRental(student, projector, 1);
app.AddRental(student, camera2, 1);

Console.WriteLine("\n===== Aktywne wypożyczenia studenta =====");
app.ShowUserActiveRentals(student.Id);

Console.WriteLine("\n===== Zwrot w terminie =====");
app.ReturnEquipment(1, false, DateTime.Now);

Console.WriteLine("\n===== Zwrot po terminie =====");
app.ReturnEquipment(2, false, DateTime.Now.AddDays(2));
app.ShowUserAllRentals(student.Id);

Console.WriteLine("\n===== Zwrot uszkodzonego sprzętu =====");
app.ReturnEquipment(3, true, DateTime.Now);
app.ShowUserAllRentals(student.Id);

Console.WriteLine("\n===== Raport końcowy =====");
app.ShowSummary();