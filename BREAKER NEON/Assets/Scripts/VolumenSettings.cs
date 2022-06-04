using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumenSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderSfx;
    public const string MUSIX_EXPOSE = "musicExpose";
    public const string SFX_EXPOSE = "sfxExpose";
    
    private void Awake()
    {
        sliderMusic.onValueChanged.AddListener(setMusicFloat);
        sliderSfx.onValueChanged.AddListener(setSfxFloat);
    }
    //desarrollo las funciones para establecer los valores de los sliders
    void setMusicFloat(float sliderMusic)
    {
        mixer.SetFloat(MUSIX_EXPOSE, Mathf.Log10(sliderMusic) * 20);
    }
    void setSfxFloat(float sliderSfx)
    {
        mixer.SetFloat(SFX_EXPOSE, Mathf.Log10(sliderSfx) * 20);
    }

    //cargamos los valores que disponibles en el playerPrefs
    void Start()
    {
        sliderMusic.value= PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY,1f);
        sliderSfx.value= PlayerPrefs.GetFloat(AudioManager.SFX_KEY,1f);
    }
    //guarda los valores de los sliders en el playerPrefs
    private void OnDisable() {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY,sliderMusic.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY,sliderSfx.value);     
    }
}