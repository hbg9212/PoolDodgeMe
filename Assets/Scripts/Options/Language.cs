using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LanguageManager : MonoBehaviour
{
    public Dropdown languageDropdown; 
    public Text textToTranslate;

    private Dictionary<string, Dictionary<string, string>> languageData;
    private string currentLanguage = "ÇÑ±¹¾î"; 

    void Start()
    {

        LoadLanguageData();
        languageDropdown.onValueChanged.AddListener(ChangeLanguage);
        UpdateText();
    }

    void LoadLanguageData()
    {
        // languageData["English"]["Hello"] = "Hello";
        // languageData["Spanish"]["Hello"] = "Hola";
        // languageData["French"]["Hello"] = "Bonjour";
    }

    void ChangeLanguage(int languageIndex)
    {
        currentLanguage = languageDropdown.options[languageIndex].text;
        UpdateText();
    }

    void UpdateText()
    {
        if (languageData.ContainsKey(currentLanguage) && languageData[currentLanguage].ContainsKey("Hello"))
        {
            textToTranslate.text = languageData[currentLanguage]["Hello"];
        }
        else
        {
            textToTranslate.text = "Translation not available.";
        }
    }
}
