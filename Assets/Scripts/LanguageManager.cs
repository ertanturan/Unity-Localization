using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LanguageManager : MonoBehaviour
{

    public static LanguageManager Instance;

    private List<Language> _languages;

    public AlphabetFontMatrix AlphabetFontMatrix { get; private set; }

    public Language SelectedLanguage { get; private set; }

    public event Action<Language> OnLanguageChange;
    private Language _defaultLanguage;

    private void Awake()
    {
        Instance = this;
        _languages = new List<Language>(
            Resources.LoadAll<Language>("Data/Localization/Languages"));
        AlphabetFontMatrix = Resources.Load<AlphabetFontMatrix>(
            "Data/Localization/AlphabetFontMatrix");
        
        _defaultLanguage = _languages[1];
        SelectedLanguage = _defaultLanguage;

    }

    public void ToggleLanguage()
    {
        SelectedLanguage = _languages
            [(_languages.IndexOf(SelectedLanguage) + 1) % _languages.Count];
        OnLanguageChange.Invoke(SelectedLanguage);
    }

    public static string GetText(LanguageDependentText text, params object[] args)
    {
        return string.Format(text.GetString(Instance.SelectedLanguage), args);
    }

    public static Sprite GetSprite(LanguageDependentSprite sprite)
    {
        return sprite.GetSprite(Instance.SelectedLanguage);
    }

    public static VideoClip GetVideoClip(LanguageDependentVideo videoClip)
    {
        return videoClip.GetVideoClip(Instance.SelectedLanguage);
    }
    
}
