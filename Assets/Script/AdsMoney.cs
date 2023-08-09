using System.Collections;
using YG;
using UnityEngine;
using UnityEngine.UI;

public class AdsMoney : MonoBehaviour
{
    [SerializeField] private YandexGame sdk;
    [SerializeField] private Text _coinsText;
    [SerializeField] private GameObject _disableButton;
    [SerializeField] private Text _timer;
    private int addedMoney = 20;
    
    public void AdButton()
    {
        sdk._RewardedShow(1);
        _disableButton.SetActive(true);
        StartCoroutine(ActiveButton());
    }

    private IEnumerator ActiveButton()
    {
        for (int i = 90; i > 0; i--)
        {
            _timer.text = i + " s";
            yield return new WaitForSeconds(1);
        }
        _disableButton.SetActive(false);
    }

    public void AdsCul()
    {
        int old = PlayerPrefs.GetInt("Coin", 0);
        int newCoins = old + addedMoney;
        PlayerPrefs.SetInt("Coin", newCoins);
        _coinsText.text = newCoins.ToString()+"$";
    }
}
