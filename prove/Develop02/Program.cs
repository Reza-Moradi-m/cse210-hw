using System;

class Program
{
    public static Journal _workingJournal = new Journal();

    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.DisplayMenu();
    }
}