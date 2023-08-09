using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Locale/Object", fileName = "new file", order = 1)]
public class LocalizationObject : ScriptableObject
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;

    public void Init(string ru, string en)
    {
        _ru = ru;
        _en = en;
    }

    public string GetLocalizationText()
    {
        switch (LocalizationGlobal.Language)
        {
            case Locale.En:
                return _en;
            case Locale.Ru:
                return _ru;
        }
        throw new ArgumentException("Язык не найден");
    }
    
}
