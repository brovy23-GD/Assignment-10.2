using System;
using System.Collections.Generic;
using System.Linq;

// This class is for Question 2.
// It lets us create employee objects with a name, salary, and age.
class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
    public int Age { get; set; }
}

// This class is for Question 5.
// It solves LeetCode 744: Next Greatest Letter using binary search.
class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        // Start with the full search range.
        int left = 0;
        int right = letters.Length;

        // Keep searching until left and right meet.
        while (left < right)
        {
            int mid = (left + right) / 2;

            // If the middle letter is greater than the target,
            // it could be our answer, but maybe there is a smaller
            // valid answer on the left side.
            if (letters[mid] > target)
            {
                right = mid;
            }
            else
            {
                // If letters[mid] is less than or equal to target,
                // it cannot be the answer, so move right.
                left = mid + 1;
            }
        }

        // If no letter is greater than target, wrap around
        // and return the first letter in the array.
        return letters[left % letters.Length];
    }
}

class Program
{
    static void Question1()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Question 1 - Positive Numbers");
        Console.WriteLine("========================================");

        // Create a list with both positive and negative numbers.
        List<int> numbers = new List<int> { 2, -1, 3, -3, 10, -200 };

        Console.WriteLine("Starting list: " + string.Join(", ", numbers));

        // Use LINQ query syntax to keep only the positive numbers.
        var positiveNumbers = from n in numbers
                              where n > 0
                              select n;

        Console.WriteLine("Positive numbers: " + string.Join(", ", positiveNumbers));
        Console.WriteLine();
    }

    static void Question2()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Question 2 - Employee Filter");
        Console.WriteLine("========================================");

        // Create a list of employee objects.
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Alice", Salary = 7200, Age = 25 },
            new Employee { Name = "Bob", Salary = 4500, Age = 28 },
            new Employee { Name = "Charlie", Salary = 8900, Age = 35 },
            new Employee { Name = "Diana", Salary = 6100, Age = 27 },
            new Employee { Name = "Edward", Salary = 3200, Age = 22 },
            new Employee { Name = "Fiona", Salary = 5500, Age = 29 },
            new Employee { Name = "George", Salary = 9100, Age = 40 }
        };

        // Filter employees who make more than 5000
        // and are younger than 30.
        var filteredEmployees = employees
            .Where(e => e.Salary > 5000 && e.Age < 30)
            .ToList();

        Console.WriteLine("Employees with Salary > 5000 and Age < 30:");

        foreach (Employee employee in filteredEmployees)
        {
            Console.WriteLine(
                $"Name: {employee.Name}, Salary: {employee.Salary}, Age: {employee.Age}");
        }

        Console.WriteLine();
    }

    static void Question3()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Question 3 - City Search");
        Console.WriteLine("========================================");

        // Create the list of city names.
        string[] cities =
        {
            "ROME",
            "LONDON",
            "NAIROBI",
            "CALIFORNIA",
            "ZURICH",
            "NEW DELHI",
            "AMSTERDAM",
            "ABU DHABI",
            "PARIS"
        };

        // These are the characters we want to search by.
        char startChar = 'A';
        char endChar = 'M';

        Console.WriteLine("Cities: " + string.Join(", ", cities));
        Console.WriteLine("Start character: " + startChar);
        Console.WriteLine("End character: " + endChar);

        // Find all cities that start with A and end with M.
        var matchingCities = from city in cities
                             where city.StartsWith(startChar.ToString()) &&
                                   city.EndsWith(endChar.ToString())
                             select city;

        foreach (string city in matchingCities)
        {
            Console.WriteLine("Matching city: " + city);
        }

        Console.WriteLine();
    }

    static void Question4()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Question 4 - Numbers Greater Than 80");
        Console.WriteLine("========================================");

        // Create the list of numbers.
        List<int> numbers = new List<int> { 55, 200, 740, 76, 230, 482, 95 };

        Console.WriteLine("Original list: " + string.Join(", ", numbers));

        // Use LINQ to keep only numbers greater than 80.
        var greaterThan80 = from n in numbers
                            where n > 80
                            select n;

        Console.WriteLine("Numbers greater than 80: " + string.Join(", ", greaterThan80));
        Console.WriteLine();
    }

    static void Question5()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("Question 5 - Next Greatest Letter");
        Console.WriteLine("========================================");

        Solution solution = new Solution();

        char[] letters1 = { 'c', 'f', 'j' };
        char target1 = 'a';
        char result1 = solution.NextGreatestLetter(letters1, target1);

        Console.WriteLine("Example 1");
        Console.WriteLine("Letters: " + string.Join(", ", letters1));
        Console.WriteLine("Target: " + target1);
        Console.WriteLine("Result: " + result1);
        Console.WriteLine();

        char[] letters2 = { 'c', 'f', 'j' };
        char target2 = 'c';
        char result2 = solution.NextGreatestLetter(letters2, target2);

        Console.WriteLine("Example 2");
        Console.WriteLine("Letters: " + string.Join(", ", letters2));
        Console.WriteLine("Target: " + target2);
        Console.WriteLine("Result: " + result2);
        Console.WriteLine();

        char[] letters3 = { 'x', 'x', 'y', 'y' };
        char target3 = 'z';
        char result3 = solution.NextGreatestLetter(letters3, target3);

        Console.WriteLine("Example 3");
        Console.WriteLine("Letters: " + string.Join(", ", letters3));
        Console.WriteLine("Target: " + target3);
        Console.WriteLine("Result: " + result3);
        Console.WriteLine();
    }

    static void Main()
    {
        // Run all five questions one after another.
        Question1();
        Question2();
        Question3();
        Question4();
        Question5();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}