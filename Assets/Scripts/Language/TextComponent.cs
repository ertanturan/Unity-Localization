using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class TextComponent : MonoBehaviour
{

    private Text _text;

    private Text Text
    {
        get
        {
            if (!_text)
                _text = GetComponent<Text>();
            return _text;
        }
    }

    private RTLTextMeshPro _textPro;

    protected RTLTextMeshPro TextPro
    {
        get
        {
            if (!_textPro)
                _textPro = GetComponent<RTLTextMeshPro>();
            return _textPro;
        }
        set
        {
            _textPro = value;
        }
    }

    protected virtual void Start()
    {
    }

    protected void SetText(string text, params object[] args)
    {
        if (Text == null)
        {
            TextPro.text = string.Format(text, args);
        }
        else
        {
            Text.text = string.Format(text, args);
        }
    }
}
