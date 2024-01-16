using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VoulumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer ourMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;


    public void SetMusicVolume()
    {

        float volume = musicSlider.value;
        ourMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);

    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
        SetSFXVolume();
    }
    public void SetSFXVolume()
    {

        float volume = sfxSlider.value;
        ourMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);

    }


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

}
