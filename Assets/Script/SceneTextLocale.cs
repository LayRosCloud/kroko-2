using UnityEngine;
using UnityEngine.UI;

public class SceneTextLocale : MonoBehaviour
{ 
    private Text _text;
    [SerializeField] private LocalizationObject _locale;
    [SerializeField] private SceneLocalization _sceneLocalization;
    private void Awake()
    {
        _text = GetComponent<Text>();
        _sceneLocalization.ChangeLocalizationEvent.AddListener(SetLocale);
    }

    private void SetLocale()
    {
        _text.text = _locale.GetLocalizationText();
    }
}
