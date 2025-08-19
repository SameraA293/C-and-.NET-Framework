using System;

// Define the Employee class
public class Employee
{
    // Property to store the employee's unique ID
    public int Id { get; set; }

    // Property to store the employee's first name
    public string FirstName { get; set; }

    // Property to store the employee's last name
    public string LastName { get; set; }

    // Overload the '==' operator to compare Employee objects by their Id
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        // If both are null, they are equal
        if (ReferenceEquals(emp1, emp2))
            return true;

        // If either is null, they are not equal
        if (emp1 is null || emp2 is null)
            return false;

        // Compare by Id
        return emp1.Id == emp2.Id;
    }

    // Overload the '!=' operator as required when '==' is overloaded
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return !(emp1 == emp2);
    }

    // Override Equals for consistency with '=='
    public override bool Equals(object obj)
    {
        return obj is Employee other && this == other;
    }

    // Override GetHashCode when Equals is overridden
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
        // Create the first Employee object and assign values
        Employee employee1 = new Employee
        {
            Id = 101,
            FirstName = "Alice",
            LastName = "Johnson"
        };

        // Create the second Employee object and assign values
        Employee employee2 = new Employee
        {
            Id = 101,  // Same Id as employee1 to test equality
            FirstName = "Bob",
            LastName = "Smith"
        };

        // Compare the two Employee objects using the overloaded '==' operator
        if (employee1 == employee2)
        {
            Console.WriteLine("The two employees are considered equal based on their Id.");
        }
        else
        {
            Console.WriteLine("The two employees are NOT equal.");
        }

        // Also demonstrate the '!=' operator
        Console.WriteLine($"Are the employees different? {employee1 != employee2}");
    }
}