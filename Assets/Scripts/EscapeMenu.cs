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
    private void Start() {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();
    }
    public void ResumeGame()
    {
        mainManager.ExitEscapeMenu();
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ExitButton()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}