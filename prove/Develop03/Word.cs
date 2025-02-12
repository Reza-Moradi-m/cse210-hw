public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool GetIsHidden() => _isHidden;

    public void Hide() => _isHidden = true;

    public void Reveal() => _isHidden = false; // Used to show all words at the end

    public string GetText() => _isHidden ? "_____" : _text;
}