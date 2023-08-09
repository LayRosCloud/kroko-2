using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SceneLocalization : MonoBehaviour
{
    public UnityEvent ChangeLocalizationEvent;
    [SerializeField] private Text _langText;
    private void Start()
    {
        StartCoroutine(SetLocaleCoroutine());
    }

    private IEnumerator SetLocaleCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        SetLocale(LocalizationGlobal.Language);
    }

    public void ChangeLocale()
    {
        SetLocale(LocalizationGlobal.Language == Locale.Ru? Locale.En : Locale.Ru);
    }
    
    private void SetLocale(Locale locale)
    {
        LocalizationGlobal.Language = locale;
        _langText.text = LocalizationGlobal.Language == Locale.Ru ? "RU" : "EN";
        ChangeLocalizationEvent.Invoke();
    }
}