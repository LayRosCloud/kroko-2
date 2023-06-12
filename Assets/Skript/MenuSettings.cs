using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private GameObject _pauseObject;
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void OnMusic(bool enabled)
    {
        float value = enabled ? 0 : -80;
        
        _audioMixerGroup.audioMixer.SetFloat("MasterVolume", value);
    }

    public void Pause()
    {
        _pauseObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _pauseObject.SetActive(false);
        Time.timeScale = 1;
    }
}
