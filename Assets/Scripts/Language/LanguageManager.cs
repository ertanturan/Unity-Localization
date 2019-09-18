using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LanguageManager : MonoBehaviour
{

    public static LanguageManager Instance;

    private Dictionary<SystemLanguage, Language> _languageDictionary 
        = new Dictionary<SystemLanguage, Language>();

    public AlphabetFontMatrix AlphabetFontMatrix { get; private set; }

    public Language SelectedLanguage { get; private set; }

    public event Action<Language> OnLanguageChange;

    private Language _defaultLanguage;

    private void Awake()
    {
        Instance = this;
        Language[] temp = new List<Language>(
            Resources.LoadAll<Language>("Data/Localization/Languages")).ToArray();
        Debug.Log(temp.Length);

        foreach (Language lang in temp)
        {
            _languageDictionary.Add(lang.systemLanguageType,lang);
        }

        AlphabetFontMatrix = Resources.Load<AlphabetFontMatrix>(
            "Data/Localization/AlphabetFontMatrix");


    }

    public void ChangeLanguage()
    {
        //SelectedLanguage = _languages
        //    [(_languages.IndexOf(SelectedLanguage) + 1) % _languages.Count];
        //OnLanguageChange.Invoke(SelectedLanguage);

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

    //public static Language GetCurrentLanguage()
    //{
    //    foreach (var VARIABLE in COLLECTION)
    //    {
            
    //    }
    //}

    public static void SetCurrentLanguage(Language lang = null , SystemLanguage syslang = SystemLanguage.English)
    {
        if (lang == null && syslang==null)
        {
            Debug.Log("No language given to set ... Returning ..");
            return;
        }
    }

    //private Language ChooseLanguage(SystemLanguage syslanguage)
    //{
    //    foreach (Language lang in _languages)
    //    {
    //        if (lang.systemLanguageType== syslanguage)
    //        {
    //            return lang;
    //        }
    //    }

    //    return _defaultLanguage;
    //}
    
}
