using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class UserInterface
    {
        private Library _library;
        private FineCalculator _fineCalculator;
        private NotificationService _notificationService;
        private DataPersistence _dataPersistence;

        public UserInterface()
        {
            _dataPersistence = new DataPersistence("librarydata.txt");
            _library = _dataPersistence.Load();
            _fineCalculator = new FineCalculator();
            _notificationService = new NotificationService();
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Library Management System ---");
                Console.WriteLine("1. Add Book (Staff Only)");
                Console.WriteLine("2. Register Member/Staff");
                Console.WriteLine("3. Check Out Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. View Overdue Loans");
                Console.WriteLine("6. List All Books");
                Console.WriteLine("7. List All Members");
                Console.WriteLine("8. Extend Due Date for a Book");
                Console.WriteLine("9. Save Data and Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBookMenu();
                        break;
                    case "2":
                        RegisterMemberMenu();
                        break;
                    case "3":
                        CheckOutBookMenu();
                        break;
                    case "4":
                        ReturnBookMenu();
                        break;
                    case "5":
                        ViewOverdueLoans();
                        break;
                    case "6":
                        ListAllBooksMenu();
                        break;
                    case "7":
                        ListAllMembersMenu();
                        break;
                    case "8":
                        ExtendDueDateMenu();
                        break;
                    case "9":
                        _dataPersistence.Save(_library);
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        private void AddBookMenu()
        {
            Console.Write("Are you Staff? (y/n): ");
            string staffCheck = Console.ReadLine()?.ToLower();
            if (staffCheck != "y")
            {
                Console.WriteLine("Only staff can add books.");
                return;
            }

            Console.Write("Enter Staff ID: ");
            string staffId = Console.ReadLine();

            Member staffMember = _library.GetMemberByID(staffId);
            if (staffMember == null || !(staffMember is Staff))
            {
                Console.WriteLine("Invalid staff ID or user is not staff.");
                return;
            }

            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();

            Book book = new Book(title, author, isbn);
            staffMember.AddBook(_library, book);
        }

        private void RegisterMemberMenu()
        {
            Console.Write("Register as Staff? (y/n): ");
            string staffCheck = Console.ReadLine()?.ToLower();

            Console.Write("Enter Member Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            if (staffCheck == "y")
            {
                Staff newStaff = new Staff(name, memberId);
                _library.RegisterMember(newStaff);
            }
            else
            {
                Member newMember = new Member(name, memberId);
                _library.RegisterMember(newMember);
            }
        }

        private void CheckOutBookMenu()
        {
            Console.Write("Enter Book ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            _library.CheckOutBook(isbn, memberId);
        }

        private void ReturnBookMenu()
        {
            Console.Write("Enter Book ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            _library.ReturnBook(isbn, memberId);
        }

        private void ViewOverdueLoans()
        {
            List<Loan> overdue = _library.GetOverdueLoans();
            if (overdue.Count == 0)
            {
                Console.WriteLine("No overdue loans found.");
            }
            else
            {
                Console.WriteLine("Overdue Loans:");
                foreach (Loan loan in overdue)
                {
                    double fine = _fineCalculator.CalculateFine(loan);
                    Console.WriteLine($"- {loan.Book.Title} (borrowed by {loan.Member.Name}), " +
                                      $"Due: {loan.DueDate.ToShortDateString()}, Fine: ${fine:0.00}");
                    _notificationService.SendNotification(loan, fine);
                }
            }
        }

        private void ListAllBooksMenu()
        {
            BookCatalog catalog = new BookCatalog(_library);
            catalog.DisplayBooks();
        }

        private void ListAllMembersMenu()
        {
            MemberDirectory directory = new MemberDirectory(_library);
            directory.DisplayMembers();
        }

        private void ExtendDueDateMenu()
        {
            Console.Write("Enter Book ISBN to extend due date: ");
            string isbn = Console.ReadLine();
            BookCatalog catalog = new BookCatalog(_library);
            catalog.ExtendDueDate(isbn);
        }
    }
}