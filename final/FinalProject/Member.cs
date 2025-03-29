using System.Collections.Generic;

namespace LibraryManagement
{
    public class Member
    {
        private string _name;
        private string _memberID;
        private List<Book> _borrowedBooks;

        public Member(string name, string memberId)
        {
            _name = name;
            _memberID = memberId;
            _borrowedBooks = new List<Book>();
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string MemberID
        {
            get => _memberID;
            set => _memberID = value;
        }

        // Expose a read-only list externally
        public IReadOnlyList<Book> BorrowedBooks => _borrowedBooks;

        // Internal list so derived classes or library can modify
        public List<Book> BorrowedBooksInternal => _borrowedBooks;

        // Virtual method for polymorphism
        public virtual void AddBook(Library library, Book book)
        {
            // By default, normal members cannot add books to the library
            // Throw an exception or simply do nothing
            // For demonstration, let's just say they can't:
            throw new System.NotSupportedException("Regular members cannot add books to the library.");
        }
    }
}