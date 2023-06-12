using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _musicMixer;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _master;
    
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeSliderSound(float value)
    {
        _musicMixer.audioMixer.SetFloat("SoundVolume",Mathf.Lerp(-80, 0, value));
        _toggle.isOn = value > 0.1f;
    }
    public void ChangeSliderMusic(float value)
    {
        _musicMixer.audioMixer.SetFloat("MusicVolume",Mathf.Lerp(-80, 0, value));
    }
    public void ChangeSliderMaster(float value)
    {
        _musicMixer.audioMixer.SetFloat("MasterVolume",Mathf.Lerp(-80, 0, value));
    }

    public void OnMusic(bool enabled)
    {
        float value = enabled ? 0 : -80;
        
        _musicMixer.audioMixer.SetFloat("MasterVolume", value);
        _master.value = enabled ? 1 : 0;
    }
}
