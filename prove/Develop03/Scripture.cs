using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string verseText)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] wordsArray = verseText.Split(' ');
        foreach (string word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideWords()
    {
        int wordsToHide = Math.Max(1, _words.Count / 10); // Hide ~10% each time

        List<int> indices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].GetIsHidden()) // Only pick words that aren't already hidden
                indices.Add(i);
        }

        for (int i = 0; i < wordsToHide && indices.Count > 0; i++)
        {
            int randIndex = _random.Next(indices.Count);
            _words[indices[randIndex]].Hide();
            indices.RemoveAt(randIndex);
        }
    }

    public void DisplayScripture()
    {
        Console.WriteLine(_reference.DisplayRef());
        foreach (Word word in _words)
        {
            Console.Write(word.GetText() + " ");
        }
        Console.WriteLine();
    }

    public bool IsAllHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.GetIsHidden())
                return false;
        }
        return true;
    }

    public void RevealAll()
    {
        Console.WriteLine(_reference.DisplayRef());
        foreach (Word word in _words)
        {
            word.Reveal();
            Console.Write(word.GetText() + " ");
        }
        Console.WriteLine();
    }
}