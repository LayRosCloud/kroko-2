using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Skins/new Skin...", order = 1, fileName = "skin-name")]
public class Skin : ScriptableObject
{
    [Header("Person info")]
    [SerializeField] private LocalizationObject _nameLocale;
    [SerializeField] private LocalizationObject _descriptionLocale;
    [Space]
    [SerializeField] private bool _isSold = false;
    [SerializeField] private int _cost;
    [Space]
    [SerializeField] private Mesh _mesh;

    private LocalizationObject _lockedDescription;

    public Mesh SkinMesh => _mesh;
    public int Cost => _cost;
    public bool IsSold => _isSold;

    public string Description
    {
        get
        {
            if (_lockedDescription == null)
            {
                _lockedDescription = CreateInstance<LocalizationObject>();
                _lockedDescription.Init("Описание заблокировано","Description locked");
            }
            return  _isSold? _descriptionLocale.GetLocalizationText() : _lockedDescription.GetLocalizationText();
        }
    }

   
    public string Name =>  _nameLocale.GetLocalizationText();
    
    public void Buy()
    {
        _isSold = true;
    }

}
