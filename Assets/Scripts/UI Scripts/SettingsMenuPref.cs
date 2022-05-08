using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuPref : MonoBehaviour
{
    private SettingsUIManager settingsUIManager;
    private void Awake() {
        FindSettingsUIM();
    }
    private void FindSettingsUIM()
    {
        settingsUIManager = GameObject.Find("Settings UI Manager").GetComponent<SettingsUIManager>();
    }
    public void VolumeSet()
    {
        settingsUIManager.MasterVolume();
    }
    public void BackButtonSetUI()
    {
        settingsUIManager.BackButton();
    }
}
