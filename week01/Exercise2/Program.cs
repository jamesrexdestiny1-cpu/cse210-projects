
using System;

// Ask the user to enter their grade percentage.
Console.Write("Enter your grade percentage: ");
int grade = int.Parse(Console.ReadLine());

// Store the letter grade and its optional sign.
string letter;
string sign = "";

// Determine the letter grade.
if (grade >= 90)
{
    letter = "A";
}
else if (grade >= 80)
{
    letter = "B";
}
else if (grade >= 70)
{
    letter = "C";
}
else if (grade >= 60)
{
    letter = "D";
}
else
{
    letter = "F";
}

// Determine the sign using the last digit of the grade.
// The remainder operator (%) gives the last digit for
// a non-negative whole-number percentage.
int lastDigit = grade % 10;

if (lastDigit >= 7)
{
    sign = "+";
}
else if (lastDigit < 3)
{
    sign = "-";
}

// A grades cannot have a plus sign.
if (letter == "A" && sign == "+")
{
    sign = "";
}

// F grades cannot have a plus or minus sign.
if (letter == "F")
{
    sign = "";
}

// Display the letter grade and its sign together.
Console.WriteLine($"Your letter grade is: {letter}{sign}");

// Check whether the student passed the course.
if (grade >= 70)
{
    Console.WriteLine("Congratulations! You passed the course!");
}
else
{
    Console.WriteLine("Keep working hard. You can do better next time!");
}
