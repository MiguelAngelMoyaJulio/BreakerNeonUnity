using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;

    //para guardar y cargar datos del playerPrefs
    public const string MUSIC_KEY = "musicExpose";
    public const string SFX_KEY = "sfxExpose";
    
    //singleton para su uso continuo
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
        loadVolume();
    }
    private void loadVolume()
    {
        float music = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfx = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        mixer.SetFloat(VolumenSettings.MUSIX_EXPOSE, Mathf.Log10(music) * 20);
        mixer.SetFloat(VolumenSettings.SFX_EXPOSE, Mathf.Log10(sfx) * 20);
    }
}
