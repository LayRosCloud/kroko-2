
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathButtons : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Text _backCounter;
    [SerializeField] private GameObject _canvasDeath;
    public void WatchAds()
    {
        Debug.Log("Вы посмотрели рекламу!");
        _player.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        _player.gameObject.transform.position = _spawnPoints[_player.CurrentPosition].position;
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
        _backCounter.text = "";
    }
    
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
