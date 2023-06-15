using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Learning : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Image _firstImage;
    [SerializeField] private Image _secondImage;
    private bool isCompleted = false;

    private void Start()
    {
        isCompleted = PlayerPrefs.GetInt("CompleteLearn", 0) == 1;
    }

    public IEnumerator StartLearnCoroutine(Action completed)
    {
        if (isCompleted == false)
        {
            yield return new WaitForSeconds(3f);
        
            var firstImageColor = _firstImage.color;
            firstImageColor.a = 0.2f;
            _firstImage.color = firstImageColor;

            Time.timeScale = 0f;
            yield return new WaitForSeconds(3f);
            firstImageColor.a = 0f;
            _firstImage.color = firstImageColor;
        
            var secondImageColor = _secondImage.color;
            secondImageColor.a = 0.2f;
            _secondImage.color = secondImageColor;
            Time.timeScale = 0f;
        
            yield return new WaitForSeconds(3f);
            secondImageColor.a = 0f;
            _secondImage.color = secondImageColor;
            isCompleted = true;
            PlayerPrefs.SetInt("CompleteLearn", 1);
        }
        
        completed();
    }
    
}
