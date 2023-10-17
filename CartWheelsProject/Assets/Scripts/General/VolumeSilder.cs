using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSilder : MonoBehaviour
{
    public string parameter;


    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource sound;

    const string SFX_VOLUME = "SoundVolume";
    const string MUSIC_VOLUME = "MusicVolume";
    const string AMBIENCE_VOLUME = "AmbienceVolume";

    private void Start()
    {
        float _value = 1;
        if (parameter == SFX_VOLUME)
        {
            mixer.GetFloat(SFX_VOLUME, out _value);
        }
        else if (parameter == MUSIC_VOLUME)
        {
            mixer.GetFloat(MUSIC_VOLUME, out _value);
        }
        else if (parameter == AMBIENCE_VOLUME)
        {
            mixer.GetFloat(AMBIENCE_VOLUME, out _value);
        }

        volumeSlider.value = Mathf.Pow(10, (_value/20));
    }

    void Awake()
    {
        if (parameter == SFX_VOLUME)
        {
            volumeSlider.onValueChanged.AddListener(SetSFXVolume);
        }
        else if (parameter == MUSIC_VOLUME)
        {
            volumeSlider.onValueChanged.AddListener(SetMusicVolume);
        }
        else if (parameter == AMBIENCE_VOLUME)
        {
            volumeSlider.onValueChanged.AddListener(SetAmbienceVolume);
        }
    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat(SFX_VOLUME, Mathf.Log10(value) * 20);
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(value) * 20);
    }

    void SetAmbienceVolume(float value)
    {
        mixer.SetFloat(AMBIENCE_VOLUME, Mathf.Log10(value) * 20);
    }

    public void playSound()
    {
        if (!sound.isPlaying)
        {
            sound.Play();
        }
    }

    public void stopSound()
    {
        if (sound.isPlaying)
        {
            sound.Stop();
        }
    }
}
