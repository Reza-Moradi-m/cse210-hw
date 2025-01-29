using System;

class Menu
{
    public void DisplayMenu()
    {
        Prompt promptGenerator = new Prompt();
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Search entries by date");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Entry newEntry = new Entry(randomPrompt);
                    Program.workingJournal.AddEntry(newEntry);
                    break;
                case "2":
                    Program.workingJournal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter the filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    Program.workingJournal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    Program.workingJournal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.Write("Enter the date (MM/DD/YYYY) to search: ");
                    string date = Console.ReadLine();
                    Program.workingJournal.SearchByDate(date);
                    break;
                case "6":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}