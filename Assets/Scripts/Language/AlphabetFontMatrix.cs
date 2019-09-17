using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public struct FontColumn
{
    public TMP_FontAsset LatinFont;
    public AlphabetFont[] AlphabetFonts;
}

[Serializable]
public struct AlphabetFont
{
    public Alphabet Alphabet;
    public TMP_FontAsset Font;
}

[CreateAssetMenu(
    fileName = "New AlphabetFontMatrix",
    menuName = "Localization/AlphabetFontMatrix",
    order = 2)]
public class AlphabetFontMatrix : ScriptableObject
{
    public FontColumn[] FontColumns;

    public TMP_FontAsset GetFont(TMP_FontAsset latinFont, Language language)
    {
        foreach(var fontcol in FontColumns)
        {
            if(fontcol.LatinFont == latinFont)
            {
                foreach(var alphabetfont in fontcol.AlphabetFonts)
                {
                    if(alphabetfont.Alphabet == language.Alphabet)
                    {
                        return alphabetfont.Font;
                    }
                }
            }
        }
        return null;
    }
}
