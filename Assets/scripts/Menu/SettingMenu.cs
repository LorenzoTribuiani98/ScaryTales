using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer mixer;

    private void Start()
    {
        mixer.SetFloat("master", 0);
        mixer.SetFloat("audio", -20);
        mixer.SetFloat("soundFX", 0);
    }

    public void setLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void setMasterVolume(float volume)
    {
        mixer.SetFloat("master", volume);
    }

    public void setAudioVolume(float volume)
    {
        mixer.SetFloat("audio", volume);
    }

    public void setSFXVolume(float volume)
    {
        mixer.SetFloat("soundFX", volume);
    }

    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
