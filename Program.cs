/*
I approached the project with the goal of creating a more engaging and insightful experience for users by implementing several advanced features beyond the core requirements:
1. Leveling System: Users level up based on accumulated points, with each level requiring progressively more points.
   - This encourages long-term motivation and a sense of achievement.
2. Goal Categories: I introduced categorization for goals (e.g., Health, Education, Spiritual), enabling users to:
   - Filter and view goals by category
   - Access category-specific progress reports
   - Maintain a balanced focus across different life areas
3. Streak Tracking: For checklist and habit-based goals, I added streak tracking functionality.
   - Users earn bonus points for maintaining streaks
   - Visual indicators display current streak status to reinforce consistency
4. Advanced Statistics:
   - Completion rate percentages for each goal type
   - Point trends over daily, weekly, and monthly periods
   - Estimated time to completion based on the user's current pace
5. Enhanced UI Features:
   - Color-coded indicators to reflect goal status at a glance
   - Progress bars for checklist-type goals
   - Keyboard shortcuts for quick access to frequent actions
These enhancements improve user engagement and provide meaningful insights into personal progress and habit development.
*/



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
