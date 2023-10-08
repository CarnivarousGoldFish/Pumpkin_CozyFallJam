using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{

    public static SettingsController instance;

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private VolumeSO volumeSO;

    [SerializeField] private GameObject settingsMenu;

    private float musicVolumeVal = 0.5f;
    private float sfxVolumeVal = 0.5f;

    public const string MUSIC_VOLUME = "MusicVolume";
    public const string SFX_VOLUME = "SFXVolume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

    }

    void Update()
    {
        mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(musicVolumeVal) * 20);
        mixer.SetFloat(SFX_VOLUME, Mathf.Log10(sfxVolumeVal) * 20);
    }

    private void SetMusicVolume(float value)
    {
        volumeSO.musicVolume = value;
    }
    private void SetSFXVolume(float value)
    {
        volumeSO.sfxVolume = value;
    }

    private void GetMusicVolume()
    {
        musicVolumeVal = volumeSO.musicVolume;
    }

    private void GetSFXVolume()
    {
        sfxVolumeVal = volumeSO.sfxVolume;
    }

    pr

}
