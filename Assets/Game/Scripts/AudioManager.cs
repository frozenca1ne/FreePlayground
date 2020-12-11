using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Music.volume = PlayerPrefs.GetFloat(PREFS_MUSIC_VOLUME, 0.5f);
            Effects.volume = PlayerPrefs.GetFloat(PREFS_EFFECTS_VOLUME, 0.5f);
        }
    }
    #endregion

    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource Effects;

    private const string PREFS_MUSIC_VOLUME = "MusicVolume";
    private const string PREFS_EFFECTS_VOLUME = "EffectsVolume";

    public void PlaySound(AudioClip audio)
    {
        Effects.PlayOneShot(audio);
    }
    public void SetMusicVolume(float volume)
    {
        Music.volume = volume;
        PlayerPrefs.SetFloat(PREFS_MUSIC_VOLUME, volume);
    }
    public void SetEffectsVolume(float volume)
    {
        Effects.volume = volume;
        PlayerPrefs.SetFloat(PREFS_EFFECTS_VOLUME, volume);
    }
    public float GetMusicVolume()
    {
        return Music.volume;
    }
    public float GetEffectsVolume()
    {
        return Effects.volume;
    }
}
