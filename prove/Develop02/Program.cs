using System;
using System.Collections.Generic;

class Program
{
    public static Journal workingJournal = new Journal();

    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.DisplayMenu();
    }
}