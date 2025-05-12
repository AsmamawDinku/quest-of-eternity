using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice;

        do
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine($"Current Score: {manager.GetScore()}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select an option: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                choice = 0; // Default value to avoid unintended behavior
            }

            switch (choice)
            {
                case 1: manager.CreateGoal(); break;
                case 2: manager.ListGoals(); break;
                case 3: manager.SaveGoals(); break;
                case 4: manager.LoadGoals(); break;
                case 5: manager.RecordEvent(); break;
                case 6: Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid option."); break;
            }

        } while (choice != 6);
    }
}
