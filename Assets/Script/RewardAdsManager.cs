using UnityEngine;
using YG;
using UnityEngine.UI;

public class RewardAdsManager : MonoBehaviour
{
    [SerializeField] private YandexGame sdk;
    [SerializeField] private DeathButtons _deathButtons;

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }

    public void AdButtonCul()
    {
        _deathButtons.WatchAds();
    }
}
