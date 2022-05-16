using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class EscapeMenu : MonoBehaviour
{
    private MainManager mainManager;
    private PlayerController playerController;
    private void Start() {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void ResumeGame()
    {
        mainManager.ExitEscapeMenu();
    }
    public void MainMenu()
    {    
        StartCoroutine(ExecuteAfterTime(0.5f));
  
        Time.timeScale = 1f;
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        PrefabSettingsMenu.prefabSettingsMenuInstance.gameObject.SetActive(true);
        PrefabSettingsMenu.prefabSettingsMenuInstance.PlayerStopAnimation();
        SceneManager.LoadScene(0);
        // Code to execute after the delay
    }
    public void ExitButton()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit()
        #endif
    }
}