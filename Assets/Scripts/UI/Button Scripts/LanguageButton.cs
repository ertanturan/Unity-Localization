using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : ButtonComponent
{
    public override Button _button { get; set; }

    [SerializeField] private LanguageManager _languageManager;
    [SerializeField] private Sprite[] _langSprites;
    //2 turkish
    //1 english
    //0 arabic

    public override void Awake()
    {
        base.Awake();
        ToggleSprite();
    }

    private void Start()
    {
        ToggleSprite();
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();
        //_languageManager.ToggleLanguage();

        ToggleSprite();
        _languageManager.ChangeLanguage();
        Debug.Log("Language Change Button Clicked .. ");

    }

    private void ToggleSprite()
    {
        //_button.image.sprite = _langSprites[_languageManager.LanguageIndex];
    }


}
