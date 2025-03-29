using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class BookCatalog
    {
        private Library _library;

        public BookCatalog(Library library)
        {
            _library = library;
        }

        public void DisplayBooks()
        {
            List<Book> books = _library.GetBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("No books registered in the library.");
                return;
            }
            Console.WriteLine("--- Book Catalog ---");
            foreach (Book book in books)
            {
                string status = book.IsCheckedOut ? "Checked Out" : "Available";
                string dueInfo = "";
                if (book.IsCheckedOut)
                {
                    Loan loan = _library.GetLoanByBook(book);
                    if (loan != null)
                    {
                        dueInfo = $", Due: {loan.DueDate.ToShortDateString()}";
                    }
                }
                Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Status: {status}{dueInfo}");
            }
        }

        // Allows a borrower to extend the due date for a book by ISBN (once only)
        public void ExtendDueDate(string isbn)
        {
            Loan loan = _library.GetLoanByISBN(isbn);
            if (loan == null)
            {
                Console.WriteLine("No active loan found for this book.");
                return;
            }
            if (loan.Extended)
            {
                Console.WriteLine("The due date for this book has already been extended.");
                return;
            }
            if (loan.ExtendDueDate())
            {
                Console.WriteLine($"Due date for '{loan.Book.Title}' extended to {loan.DueDate.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine("Unable to extend due date.");
            }
        }
    }
}