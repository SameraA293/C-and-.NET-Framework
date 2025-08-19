using System;

// Define an interface named IQuittable
public interface IQuittable
{
    // Declare a method signature for Quit
    void Quit();
}


using System;

// Employee class inherits from IQuittable interface
public class Employee : IQuittable
{
    // Property to store employee ID
    public int Id { get; set; }

    // Property to store employee's first name
    public string FirstName { get; set; }

    // Property to store employee's last name
    public string LastName { get; set; }

    // Implement the Quit method from IQuittable interface
    public void Quit()
    {
        // Display a message when the employee quits
        Console.WriteLine($"{FirstName} {LastName} (ID: {Id}) has quit the job.");
    }

    // Overload the '==' operator to compare Employee objects by Id
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        if (ReferenceEquals(emp1, emp2))
            return true;

        if (emp1 is null || emp2 is null)
            return false;

        return emp1.Id == emp2.Id;
    }

    // Overload the '!=' operator as required
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return !(emp1 == emp2);
    }

    // Override Equals for consistency
    public override bool Equals(object obj)
    {
        return obj is Employee other && this == other;
    }

    // Override GetHashCode
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}


using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of Employee and assign values
        Employee employee = new Employee
        {
            Id = 202,
            FirstName = "Jordan",
            LastName = "Lee"
        };

        // Use polymorphism: assign Employee object to an IQuittable interface reference
        IQuittable quittableEmployee = employee;

        // Call the Quit method using the interface reference
        quittableEmployee.Quit();

        // Keep the console window open
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
