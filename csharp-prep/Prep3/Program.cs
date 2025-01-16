using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

        Random randomNumber = new Random();
        int magicNumber = randomNumber.Next(1, 101);

        int Answer = 0;

        while (Answer != magicNumber)
        {
            Console.Write("What is the magic number? ");
        string input = Console.ReadLine();
        
        
        Answer = int.Parse(input);

        if (Answer == magicNumber)
        {
            Console.WriteLine("You guessed the magic number!");
        }
        else if (Answer < magicNumber)
        {
            Console.WriteLine("Your guess is too low.");
        }
        else if (Answer > magicNumber)
        {
            Console.WriteLine("Your guess is too high.");
        }}
    }
}