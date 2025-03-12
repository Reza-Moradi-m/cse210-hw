using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        while (true)
        {
            menu.DisplayMenu();
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    menu.CreateGoal();
                    break;
                case "2":
                    menu.RecordGoalEvent();
                    break;
                case "3":
                    menu.ReportNegativeBehavior();  // New feature to deduct points
                    break;
                case "4":
                    menu.DisplayGoals();
                    break;
                case "5":
                    menu.Save();
                    break;
                case "6":
                    menu.Load();
                    break;
                case "7":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}