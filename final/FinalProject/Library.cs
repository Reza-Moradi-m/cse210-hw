using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class Library
    {
        private List<Book> _books;
        private List<Member> _members;
        private List<Loan> _loans;

        public Library()
        {
            _books = new List<Book>();
            _members = new List<Member>();
            _loans = new List<Loan>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to the library.");
        }

        public void RegisterMember(Member member)
        {
            _members.Add(member);
            Console.WriteLine($"Member registered: {member.Name} (ID: {member.MemberID})");
        }

        public void CheckOutBook(string isbn, string memberId)
        {
            Book book = _books.Find(b => b.ISBN == isbn && !b.IsCheckedOut);
            Member member = _members.Find(m => m.MemberID == memberId);

            if (book == null)
            {
                Console.WriteLine("Book not found or already checked out.");
                return;
            }
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            book.IsCheckedOut = true;
            Loan loan = new Loan(book, member, DateTime.Now, DateTime.Now.AddDays(14));
            _loans.Add(loan);
            member.BorrowedBooksInternal.Add(book);

            Console.WriteLine($"Book '{book.Title}' checked out to {member.Name}. Due: {loan.DueDate.ToShortDateString()}");
        }

        public void ReturnBook(string isbn, string memberId)
        {
            Loan loan = _loans.Find(l => l.Book.ISBN == isbn && l.Member.MemberID == memberId);
            if (loan == null)
            {
                Console.WriteLine("No matching loan found.");
                return;
            }

            loan.Book.IsCheckedOut = false;
            loan.Member.BorrowedBooksInternal.Remove(loan.Book);
            _loans.Remove(loan);

            Console.WriteLine($"Book '{loan.Book.Title}' returned by {loan.Member.Name}.");
        }

        public List<Loan> GetOverdueLoans()
        {
            return _loans.FindAll(l => l.IsOverdue());
        }

        // NEW: Returns all registered books
        public List<Book> GetBooks()
        {
            return _books;
        }

        // NEW: Returns the loan associated with a given book (if any)
        public Loan GetLoanByBook(Book book)
        {
            return _loans.Find(l => l.Book == book);
        }

        // NEW: Returns the loan for a book with the given ISBN
        public Loan GetLoanByISBN(string isbn)
        {
            return _loans.Find(l => l.Book.ISBN == isbn);
        }

        // NEW: Returns all registered members
        public List<Member> GetMembers()
        {
            return _members;
        }

        // NEW: Returns all loans
        public List<Loan> GetLoans()
        {
            return _loans;
        }

        // NEW: Adds a loan to the internal list (used during data loading)
        public void AddLoan(Loan loan)
        {
            _loans.Add(loan);
            if (!loan.Member.BorrowedBooksInternal.Contains(loan.Book))
            {
                loan.Member.BorrowedBooksInternal.Add(loan.Book);
            }
        }

        // NEW: Retrieve a member by their ID
        public Member GetMemberByID(string memberId)
        {
            return _members.Find(m => m.MemberID == memberId);
        }
    }
}