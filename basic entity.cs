public class Student
{
    public int StudentId { get; set; }  // Primary Key
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

using System.Data.Entity;

public class StudentContext : DbContext
{
    public StudentContext() : base("StudentDbConnection") { }

    public DbSet<Student> Students { get; set; }
}


using System;


<configuration>
  <connectionStrings>
    <add name="StudentDbConnection"
         connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>

class Program
{
    static void Main(string[] args)
    {
        using (var context = new StudentContext())
        {
            var student = new Student
            {
                FirstName = "Emma",
                LastName = "Thompson",
                Age = 22
            };

            context.Students.Add(student);
            context.SaveChanges();

            Console.WriteLine("Student added successfully!");
        }

        Console.ReadLine();
    }
}
