using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Locale/Object", fileName = "new file", order = 1)]
public class LocalizationObject : ScriptableObject
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;

    private readonly Dictionary<Locale, string> _table = new();
    
    public LocalizationObject()
    {
        _table.Add(Locale.Ru, _ru);
        _table.Add(Locale.En, _en);
    }

    public string GetLocalizationText()
    {
        return _table.GetValueOrDefault(LocalizationGlobal.Language);
    }
    
}
