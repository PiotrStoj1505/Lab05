using System;
using System.Collections.Generic;

class Coords
{
    public double X { get; set; }
    public double Y { get; set; }

    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static double Distance(Coords point1, Coords point2)
    {
        return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
    }

    public static double PolylineLength(List<Coords> points)
    {
        double length = 0;

        for (int i = 0; i < points.Count - 1; i++)
        {
            length += Distance(points[i], points[i + 1]);
        }

        return length;
    }
}

class Program
{
    static (int Min, int Max) FindMinMax(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
        {
            throw new ArgumentException("Tablica nie może być pusta.");
        }

        int min = numbers[0];
        int max = numbers[0];

        foreach (int num in numbers)
        {
            if (num < min)
                min = num;
            if (num > max)
                max = num;
        }

        return (min, max);
    }

    static void Main()
    {
        // ZADANIE 1
        Console.WriteLine("ZADANIE 1: Obliczanie długości łamanej");

        var polylinePoints = new List<Coords>
        {
            new Coords(0, 0),
            new Coords(3, 4),
            new Coords(6, 4),
            new Coords(10, 0)
        };

        double totalLength = Coords.PolylineLength(polylinePoints);
        Console.WriteLine($"Całkowita długość łamanej: {totalLength}");

        // ZADANIE 2
        Console.WriteLine("\nZADANIE 2: Znalezienie wartości minimalnej i maksymalnej w tablicy");

        int[] numbers = { 5, 2, 9, -3, 7, 10, -1 };
        var result = FindMinMax(numbers);

        Console.WriteLine($"Najmniejsza liczba: {result.Min}");
        Console.WriteLine($"Największa liczba: {result.Max}");

        // ZADANIE 3
        Console.WriteLine("\nZADANIE 3: Klasa Person");

        Person person1 = new Person("Jan", "Kowalski", new DateTime(2000, 5, 20));
        Person person2 = new Person("Anna", "Nowak", new DateTime(2010, 3, 15));
        person1.EmailAddress = "jan.kowalski@example.com";
        person2.EmailAddress = "anna.nowak@example.com";

        Console.WriteLine($"{person1.GetFullName()}, Wiek: {person1.GetAge()}, Dorosły: {person1.IsAdult()}, Email: {person1.EmailAddress}");
        Console.WriteLine($"{person2.GetFullName()}, Wiek: {person2.GetAge()}, Dorosły: {person2.IsAdult()}, Email: {person2.EmailAddress}");
    }
}

public class Person
{
    // Właściwości
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string EmailAddress { get; set; }

    // Konstruktor
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // Konstruktor rozszerzony
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    // Metoda zwracająca pełne imię i nazwisko
    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    // Metoda zwracająca wiek
    public int GetAge()
    {
        int age = DateTime.Now.Year - BirthDate.Year;
        if (DateTime.Now.Date < BirthDate.AddYears(age)) age--;
        return age;
    }

    // Metoda sprawdzająca, czy osoba jest dorosła
    public bool IsAdult()
    {
        return GetAge() >= 18;
    }
}
