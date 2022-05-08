using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backGroundAudio;
    public AudioSource gameOverAudio;
    public AudioSource upgradeSound;
    public AudioSource takeCubeSound;
    public AudioSource downSound;
    public PlayerController playerControllerSC;
    public SettingsUIManager settingsUIManager;

    private List<AudioSource> effects = new List<AudioSource>();
    private void Awake() {
        FindSoundEffects();
        FindSettingsUIManager();
 
        PlayBackGroundMusic();
        FindPlayerController();
    }
    
    private void FindSoundEffects()
    {
        effects.AddRange(GetComponents<AudioSource>());
    }
    private void FindEffects(float volume)
    {
        for(int i = 0;i<effects.Count;i++)
        {
            if(effects[i].clip.name =="Background Music")
            {
                backGroundAudio = effects[i];
                backGroundAudio.volume=volume;
            }
            else if(effects[i].clip.name =="Game Over")
            {
                gameOverAudio = effects[i];
                gameOverAudio.volume=volume;
            }
            else if(effects[i].clip.name =="Take Cube")
            {
                takeCubeSound = effects[i];
                takeCubeSound.volume=volume;
            }
            else if(effects[i].clip.name =="Upgrade Sound")
            {
                upgradeSound = effects[i];
                upgradeSound.volume=volume;
            }
            else if(effects[i].clip.name =="Downer")
            {
                downSound = effects[i];
                downSound.volume=volume;
            }
        }
    }
    
    private float VolumeSet()
    {
        return settingsUIManager.volume;
    }
    private void PlayBackGroundMusic()
    {
        backGroundAudio.Play();
    }

    private void FindPlayerController()
    {
        playerControllerSC = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void FindSettingsUIManager()
    {
        try
        {
            settingsUIManager = GameObject.Find("Settings UI Manager").GetComponent<SettingsUIManager>();
            FindEffects(VolumeSet());
        }
        catch
        {
            FindEffects(1f);
        }  
    }
    public void GameIsStoppedSound()
    {
        backGroundAudio.Stop();
        gameOverAudio.Play();
    }
    public void CubeTakedSound()
    {
        takeCubeSound.Play();
    }
    public void UpgradeSound()
    {
        upgradeSound.Play();
    }
    public void DownSound()
    {
        downSound.Play();
    }
}