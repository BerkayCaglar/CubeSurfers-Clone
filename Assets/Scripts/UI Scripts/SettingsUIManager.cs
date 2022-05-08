using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingsUIManager : MonoBehaviour
{
    public static SettingsUIManager SettingsUIManagerInstance;
    private AudioSource audioSource;
    public Slider masterVolumeSlider;
    public float volume;
    public void MasterVolume()
    {
       volume = masterVolumeSlider.value;
       audioSource.volume = masterVolumeSlider.value;
    }
    private void FixedUpdate() {
        if(masterVolumeSlider == null)
        {
            FindMasterVolumeSlider();
        }
    }
    private void Awake() {
       FindMenuMusic();
       SetVolumeSlider();
       if(SettingsUIManagerInstance == null)
       {
           SettingsUIManagerInstance = this;
           DontDestroyOnLoad(gameObject);
       }
       if(SettingsUIManagerInstance != this)
       {
           Destroy(gameObject);
       }
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    private void Start() {
        volume = 1;
    }
    private void FindMenuMusic()
    {
        audioSource = GameObject.Find("Player Menu Prefab").GetComponent<AudioSource>();
    }
    private void SetVolumeSlider()
    {
        try
        {
            masterVolumeSlider.value = audioSource.volume;
        }
        catch
        {

        }
    }
    private void FindMasterVolumeSlider()
    {
        masterVolumeSlider = GameObject.Find("Canvas").GetComponentInChildren<Slider>();
    }
}