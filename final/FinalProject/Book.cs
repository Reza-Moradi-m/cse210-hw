namespace LibraryManagement
{
    public class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private bool _isCheckedOut;

        public Book(string title, string author, string isbn)
        {
            _title = title;
            _author = author;
            _isbn = isbn;
            _isCheckedOut = false;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public string ISBN
        {
            get => _isbn;
            set => _isbn = value;
        }

        public bool IsCheckedOut
        {
            get => _isCheckedOut;
            set => _isCheckedOut = value;
        }
    }
}