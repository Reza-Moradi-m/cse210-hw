public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse1;
    private string _verseEnd;

    // ✅ Constructor for single verse
    public Reference(string book, string chapter, string verse1)
    {
        _book = book;
        _chapter = chapter;
        _verse1 = verse1;
        _verseEnd = verse1;
    }

    // ✅ Constructor for multiple verses
    public Reference(string book, string chapter, string verse1, string verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verse1 = verse1;
        _verseEnd = verseEnd;
    }

    // ✅ New constructor for book + chapter only
    public Reference(string book, string chapter)
    {
        _book = book;
        _chapter = chapter;
        _verse1 = "";  // No verse number
        _verseEnd = "";
    }

    public string DisplayRef()
    {
        if (!string.IsNullOrEmpty(_verse1))
        {
            return _verse1 == _verseEnd ? $"{_book} {_chapter}:{_verse1}" : $"{_book} {_chapter}:{_verse1}-{_verseEnd}";
        }
        else
        {
            return $"{_book} {_chapter}"; // Display only book and chapter
        }
    }
}