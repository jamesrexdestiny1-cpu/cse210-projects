
using System;
using System.Collections.Generic;

// Create a list to store the numbers entered by the user.
List<int> numbers = new List<int>();

// Ask the user to enter numbers until they enter 0.
Console.WriteLine("Enter a list of numbers, type 0 when finished.");

while (true)
{
    // Prompt the user to enter a number.
    Console.Write("Enter number: ");
    int number = int.Parse(Console.ReadLine());

    // Stop collecting numbers when the user enters 0.
    // Zero is not added to the list.
    if (number == 0)
    {
        break;
    }

    // Add the entered number to the list.
    numbers.Add(number);
}

// Check whether the user entered at least one number.
if (numbers.Count == 0)
{
    Console.WriteLine("No numbers were entered. Please run the program again.");
}
else
{
    // Calculate the sum of all numbers in the list.
    int sum = 0;

    foreach (int number in numbers)
    {
        sum += number;
    }

    // Calculate the average using double to allow decimal results.
    double average = (double)sum / numbers.Count;

    // Find the largest number in the list.
    int largest = numbers[0];

    foreach (int number in numbers)
    {
        if (number > largest)
        {
            largest = number;
        }
    }

    // Display the sum, average, and largest number.
    Console.WriteLine($"The sum is: {sum}");
    Console.WriteLine($"The average is: {average}");
    Console.WriteLine($"The largest number is: {largest}");

    // Find all positive numbers and identify the smallest one.
    // Start with null because a positive number may not exist.
    int? smallestPositive = null;

    foreach (int number in numbers)
    {
        // Ignore zero and negative numbers.
        if (number > 0)
        {
            // Store the first positive number, then compare
            // later positive numbers with the current smallest.
            if (smallestPositive == null || number < smallestPositive)
            {
                smallestPositive = number;
            }
        }
    }

    // Display the smallest positive number, if one exists.
    if (smallestPositive != null)
    {
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
    }
    else
    {
        Console.WriteLine("There are no positive numbers in the list.");
    }

    // Sort the list from smallest to largest.
    numbers.Sort();

    // Display each number in the sorted list on a new line.
    Console.WriteLine("The sorted list is:");

    foreach (int number in numbers)
    {
        Console.WriteLine(number);
    }
}
