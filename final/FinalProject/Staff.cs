namespace LibraryManagement
{
    public class Staff : Member
    {
        public Staff(string name, string memberId) : base(name, memberId)
        {
        }

        // Overriding the virtual method from Member
        public override void AddBook(Library library, Book book)
        {
            // Staff can actually add books to the library
            library.AddBook(book);
        }
    }
}