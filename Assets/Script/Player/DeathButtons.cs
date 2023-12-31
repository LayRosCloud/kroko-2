﻿
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathButtons : MonoBehaviour
{
    [SerializeField] private PlayerPosition _player;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Text _backCounter;
    [SerializeField] private GameObject _canvasDeath;

    [SerializeField] private PlayerDeath _playerDeath;
    
    
    
    public void WatchAds()
    {
        _player.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        _player.gameObject.GetComponent<Collider>().enabled = false;
        _player.gameObject.transform.position = _spawnPoints[_player.GetPosition()].position;
        _canvasDeath.SetActive(false);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        _backCounter.text = "1";
        yield return new WaitForSeconds(1f);
        
        _backCounter.text = "2";
        yield return new WaitForSeconds(1f);
        
        _backCounter.text = "3";
        yield return new WaitForSeconds(1f);
        
        _player.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        _player.gameObject.GetComponent<Collider>().enabled = true;
        _backCounter.text = "";
        
        _playerDeath.Heal();
    }
    
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
