using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIManager : MonoBehaviour
{
    public static UIManager InstanceUIManager;
    [SerializeField]
    private TMP_Text alertText;
    public TMP_Text scoreText;
    public TMP_Text nameText;
    public TMP_Text nameTextInputArea;
    public TMP_Text noHighScore;
    public List<GameObject> gameObjects = new List<GameObject>();
    public class BestScoreMainMenu
    {
        public string name;
        public string score;
    }
    public class Name
    {
        public string playerName;
    }
    private void Start() {
        CheckBestScore();
    }
    private void Awake() {
        string path = Application.persistentDataPath+"/playerdata.json";
        if(File.Exists(path))
        {
            File.Delete(path);
        }
    }
    public void StartButton()
    {
        if(PlayerNameIsEntered())
        {
            // start of new code
            if (InstanceUIManager != null)
            {
                Destroy(gameObject);
                return;
            }
            // end of new code
            InstanceUIManager = this;
            DontDestroyOnLoad(gameObject);

            NameToJavaScriptFile();
            //Destroy(GameObject.Find("Player Menu Prefab"));
            GameObject.Find("Player Menu Prefab").gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
        else
        {
            alertText.gameObject.SetActive(true);
        }
    }
    public void SettingsButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
    private bool PlayerNameIsEntered()
    {
        
        if(GetPlayerNameInInputTextArea().Length <=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public string GetPlayerNameInInputTextArea()
    {
        return GameObject.Find("Canvas").GetComponentInChildren<TMP_InputField>().text;
    }

    public void NameToJavaScriptFile()
    {
        Name playerData = new Name();
        playerData.playerName = GetPlayerNameInInputTextArea();

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath+"/playerdata.json",json); 
    }
    public string ReturnPlayerName()
    {
        string path = Application.persistentDataPath+"/playerdata.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Name playerData = JsonUtility.FromJson<Name>(json);
            return playerData.playerName;
        }
        else
        {
            return "SELAM";
        }
    }
    //Settings Menu Function
    public void BackButtonSettingsMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void CheckBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScoreMainMenu bestMain = JsonUtility.FromJson<BestScoreMainMenu>(json);

            nameText.text = bestMain.name;
            scoreText.text = bestMain.score;
            noHighScore.gameObject.SetActive(false);
        }
    }
}
