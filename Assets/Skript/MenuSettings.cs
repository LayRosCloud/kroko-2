using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private GameObject _pauseObject;
    [SerializeField] private GameObject _onMusicOn;
    [SerializeField] private GameObject _onMusicOff;

    private void Start()
    {
        int value = PlayerPrefs.GetInt("MasterVolume", 0);
        OnMusic(value == 0);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void OnMusic(bool enabled)
    {
        int value = enabled ? 0 : -80;
        
        _audioMixerGroup.audioMixer.SetFloat("MasterVolume", value);
        PlayerPrefs.SetInt("MasterVolume", value);
        _onMusicOn.SetActive(enabled);
        _onMusicOff.SetActive(enabled == false);
    }

    public void Pause()
    {
        _pauseObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _pauseObject.SetActive(false);
        Time.timeScale = 1;
    }
}
