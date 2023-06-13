using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject _back;
    [SerializeField] private GameObject _btnVideo;
    [SerializeField] private GameObject _skip;
    [SerializeField] private GameObject Time;
    [SerializeField] private Scope Scope;
    private void SetActiveFalse()
    {
        _back.SetActive(false);
        _btnVideo.SetActive(false);
        _skip.SetActive(true);
        gameObject.SetActive(false);
        Scope.DeathBool = false;
        Time.SetActive(false);
    }
}
