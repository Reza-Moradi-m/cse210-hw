using System;
using System.IO;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class DataPersistence
    {
        private string _filePath;

        public DataPersistence(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(Library library)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                // Save Books
                writer.WriteLine("[Books]");
                foreach (Book book in library.GetBooks())
                {
                    writer.WriteLine($"{book.ISBN}|{book.Title}|{book.Author}|{book.IsCheckedOut}");
                }
                writer.WriteLine();

                // Save Members
                writer.WriteLine("[Members]");
                foreach (Member member in library.GetMembers())
                {
                    string role = (member is Staff) ? "Staff" : "Member";
                    writer.WriteLine($"{member.MemberID}|{member.Name}|{role}");
                }
                writer.WriteLine();

                // Save Loans
                writer.WriteLine("[Loans]");
                foreach (Loan loan in library.GetLoans())
                {
                    writer.WriteLine($"{loan.Book.ISBN}|{loan.Member.MemberID}|{loan.LoanDate:o}|{loan.DueDate:o}|{loan.Extended}");
                }
            }
            Console.WriteLine("Data saved successfully.");
        }

        public Library Load()
        {
            Library library = new Library();
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Data file not found. Starting with an empty library.");
                return library;
            }

            Dictionary<string, Book> booksDict = new Dictionary<string, Book>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string section = "";
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        section = line.Trim('[', ']');
                        continue;
                    }
                    string[] parts = line.Split('|');
                    if (section == "Books")
                    {
                        if (parts.Length < 4) continue;
                        string isbn = parts[0];
                        string title = parts[1];
                        string author = parts[2];
                        bool isCheckedOut = bool.Parse(parts[3]);
                        Book book = new Book(title, author, isbn);
                        book.IsCheckedOut = isCheckedOut;
                        library.AddBook(book);
                        booksDict[isbn] = book;
                    }
                    else if (section == "Members")
                    {
                        if (parts.Length < 3) continue;
                        string memberId = parts[0];
                        string name = parts[1];
                        string role = parts[2];
                        if (role == "Staff")
                        {
                            Staff staff = new Staff(name, memberId);
                            library.RegisterMember(staff);
                        }
                        else
                        {
                            Member member = new Member(name, memberId);
                            library.RegisterMember(member);
                        }
                    }
                    else if (section == "Loans")
                    {
                        if (parts.Length < 5) continue;
                        string isbn = parts[0];
                        string memberId = parts[1];
                        DateTime loanDate = DateTime.Parse(parts[2]);
                        DateTime dueDate = DateTime.Parse(parts[3]);
                        bool extended = bool.Parse(parts[4]);
                        Book book = booksDict.ContainsKey(isbn) ? booksDict[isbn] : null;
                        Member member = library.GetMemberByID(memberId);
                        if (book != null && member != null)
                        {
                            Loan loan = new Loan(book, member, loanDate, dueDate);
                            if (extended && !loan.Extended)
                            {
                                loan.ExtendDueDate();
                            }
                            library.AddLoan(loan);
                        }
                    }
                }
            }
            Console.WriteLine("Data loaded successfully.");
            return library;
        }
    }
}