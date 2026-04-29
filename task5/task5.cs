using System;
using System.Linq;

class Student
{
    private static int _nextId = 1; //ID автоматты түрде өсу

    public int StudentId { get; private set; }
    public string Name { get; set; }
    public string Faculty { get; set; }

    private double _gpa;
    public double GPA
    {
        get => _gpa;
        set
        {
            // GPA тексеру (0.0 - 4.0)
            if (value < 0.0 || value > 4.0)
                throw new ArgumentOutOfRangeException(nameof(GPA), "GPA must be between 0.0 and 4.0.");
            _gpa = value;
        }
    }

    public Student(string name, double gpa, string faculty)
    {
        StudentId = _nextId++; // Автоматты түрде ID беру
        Name = name;
        GPA = gpa;
        Faculty = faculty;
    }

    //ToString
    public override string ToString() =>
        $"[ID: {StudentId,3}]  {Name,-20}  GPA: {GPA:F2}  Faculty: {Faculty}";
}

class Registry
{
    private const int MaxCapacity = 100;
    private readonly Student[] _students = new Student[MaxCapacity];
    private int _count = 0;

    public bool Add(Student student)
    {
        if (_count >= MaxCapacity)
        {
            Console.WriteLine("Registry is full (100 students).");
            return false;
        }
        _students[_count++] = student;
        return true;
    }

    public Student FindById(int id)
    {
        for (int i = 0; i < _count; i++)
            if (_students[i].StudentId == id)
                return _students[i];
        return null;
    }

    public Student[] FindByName(string name)
    {
        string lower = name.ToLower();
        return _students
               .Take(_count)
               .Where(s => s.Name.ToLower().Contains(lower))
               .ToArray();
    }

    public Student[] GetTopStudents(int n)
    {
        return _students
               .Take(_count)
               .OrderByDescending(s => s.GPA)
               .Take(n)
               .ToArray();
    }

    public void PrintAll()
    {
        if (_count == 0)
        {
            Console.WriteLine("No students in the registry.");
            return;
        }
        Console.WriteLine($"\n{"ID",-6} {"Name",-20} {"GPA",-6} Faculty");
        Console.WriteLine(new string('-', 55));
        for (int i = 0; i < _count; i++)
        {
            //автоматты түрде ToString() шақырылады
            Console.WriteLine(_students[i]);
        }
    }
}

class Program
{
    static readonly Registry registry = new Registry();

    static void Main()
    {
        TryAddSilent("Aisha Bekova", 3.9, "Computer Science");
        TryAddSilent("Daniyar Seitkali", 3.4, "Mathematics");
        TryAddSilent("Zarina Mukhanova", 3.7, "Physics");

        bool running = true;
        while (running)
        {
            PrintMenu();
            string choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1": AddStudent(); break;
                case "2": FindById(); break;
                case "3": FindByName(); break;
                case "4": ShowTopStudents(); break;
                case "5": registry.PrintAll(); break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    static void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine(" ~~~ STUDENT REGISTRY SYSTEM ~~~");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Find by ID");
        Console.WriteLine("3. Find by Name");
        Console.WriteLine("4. Top N Students");
        Console.WriteLine("5. Print All");
        Console.WriteLine("6. Exit");
        Console.Write("Choose: ");
    }

    static void AddStudent()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("GPA: ");
        double.TryParse(Console.ReadLine(), out double gpa);
        Console.Write("Faculty: ");
        string faculty = Console.ReadLine();

        try
        {
            var student = new Student(name, gpa, faculty);
            if (registry.Add(student))
                // Бұл жерде де ToString() қолданылады
                Console.WriteLine($"\nAdded: {student}");
        }
        catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
    }

    static void FindById()
    {
        Console.Write("Enter ID: ");
        int.TryParse(Console.ReadLine(), out int id);
        var s = registry.FindById(id);
        Console.WriteLine(s != null ? $"Found: {s}" : "Not found.");
    }

    static void FindByName()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        var results = registry.FindByName(name);
        foreach (var s in results) Console.WriteLine(s);
    }

    static void ShowTopStudents()
    {
        Console.Write("How many (N): ");
        int.TryParse(Console.ReadLine(), out int n);
        var top = registry.GetTopStudents(n);
        foreach (var s in top) Console.WriteLine(s);
    }

    static void TryAddSilent(string name, double gpa, string faculty)
    {
        try { registry.Add(new Student(name, gpa, faculty)); } catch { }
    }
}