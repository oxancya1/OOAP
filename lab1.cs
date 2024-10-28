using System;
using System.Collections.Generic;

// Інтерфейс працівника
public interface IEmployee
{
    string Name { get; }
    string Position { get; }
    decimal CalculateSalary();
}

// Базовий клас Employee
public class Employee : IEmployee
{
    public string Name { get; private set; }
    public string Position { get; private set; }

    // Об'єкт, який відповідає за делегування розрахунку зарплати
    protected SalaryCalculator salaryCalculator;

    public Employee(string name, string position, SalaryCalculator salaryCalculator)
    {
        Name = name;
        Position = position;
        this.salaryCalculator = salaryCalculator;
    }

    public decimal CalculateSalary()
    {
        // Делегуємо розрахунок зарплати об'єкту SalaryCalculator
        return salaryCalculator.Calculate();
    }
}

// Інтерфейс для делегування розрахунку зарплати
public interface SalaryCalculator
{
    decimal Calculate();
}

// Реалізація розрахунку для конкретних посад
public class DepartmentHeadSalaryCalculator : SalaryCalculator
{
    public decimal Calculate()
    {
        return 50000M; // Фіксована зарплата 50,000 грн
    }
}

public class ChiefEngineerSalaryCalculator : SalaryCalculator
{
    public decimal Calculate()
    {
        return 40000M; // Фіксована зарплата 40,000 грн
    }
}

public class SoftwareEngineerSalaryCalculator : SalaryCalculator
{
    public decimal Calculate()
    {
        return 35000M; // Фіксована зарплата 35,000 грн
    }
}

public class SystemAdministratorSalaryCalculator : SalaryCalculator
{
    public decimal Calculate()
    {
        return 30000M; // Фіксована зарплата 30,000 грн
    }
}

// Програма 
class Program
{
    static void Main(string[] args)
    {
        List<IEmployee> employees = new List<IEmployee>
        {
            new Employee("Іван Іванович", "Начальник відділу", new DepartmentHeadSalaryCalculator()),
            new Employee("Петро Петрович", "Головний інженер", new ChiefEngineerSalaryCalculator()),
            new Employee("Олександр Олександрович", "Інженер-програміст", new SoftwareEngineerSalaryCalculator()),
            new Employee("Микола Миколайович", "Системний адміністратор", new SystemAdministratorSalaryCalculator())
        };

        foreach (var employee in employees)
        {
            Console.WriteLine($"Посада: {employee.Position}, Ім'я: {employee.Name}, Зарплата: {employee.CalculateSalary()} грн");
        }
    }
}