using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    [SerializeField] private AudioSource _moneySound;
    [SerializeField] private Text _scoreCoin;

    private void Start()
    {
        int coinScore = PlayerPrefs.GetInt("Coin", 0);
        _scoreCoin.text = coinScore.ToString();
    }

    private void OnEnable()
    {
        DisplayEvents.AddMoney += AddMoney;
    }

    private void OnDisable()
    {
        DisplayEvents.AddMoney -= AddMoney;
    }

    private void OnDestroy()
    {
        DisplayEvents.AddMoney -= AddMoney;
    }

    private void AddMoney(int value)
    {
        _moneySound.Play();
        _scoreCoin.text = value.ToString();
    }
}
