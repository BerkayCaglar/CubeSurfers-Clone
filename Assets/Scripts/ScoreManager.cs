using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pointText;

    [SerializeField]
    private TMP_Text extraPointText;
    public TMP_Text pressSpaceBar;
    private UIManager uIManager;
    private CubeManager cubeManager;
    private int cubePoint=2;
    private int extraPoint=5;
    private int numberOfWork = 0;
    private int number=0;

    class BestScore
    {
        public string name;
        public string score;
    }
    class Level
    {
        public string level;
    }
    private void Start() {
        pointText.text = "0";
        FindUIManager();
    }
    public void UpdateScorePerCube()
    {
        UpdateScoreNormal();
        if(ConvertCurrentScore() % 5 ==0 && pointText.text !="0")
        {
            UpdateScoreFive();
        }
    }
    public int ConvertCurrentScore()
    {
        return Convert.ToInt32(pointText.text);
    }
    private int ConvertCurrentHighScore()
    {
        string path = Application.persistentDataPath+"/bestscore.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore bestMain = JsonUtility.FromJson<BestScore>(json);
            return Convert.ToInt32(bestMain.score);
        }
        else
        {
            return 0;
        }
    }
    private void UpdateScoreNormal()
    {
        pointText.text =Convert.ToString(ConvertCurrentScore() + cubePoint);
        extraPointText.gameObject.SetActive(false);
    }
    private void UpdateScoreFive()
    {
        pointText.text =Convert.ToString(ConvertCurrentScore() + extraPoint);
        extraPointText.gameObject.SetActive(true);
    }
    public void SendScoreToSaveFile(int extra)
    {
        numberOfWork ++;
        if(numberOfWork ==1)
        {
            pointText.text =Convert.ToString(ConvertCurrentScore() + extra);
            if(ConvertCurrentScore()>ConvertCurrentHighScore())
            {
                BestScore best = new BestScore();
                best.name = uIManager.ReturnPlayerName();
                best.score = Convert.ToString(ConvertCurrentScore());

                string json = JsonUtility.ToJson(best);
                File.WriteAllText(Application.persistentDataPath+"/bestscore.json",json);   
            }
        }
    }
    public int ConvertLevelJson()
    {
        string path = Application.persistentDataPath+"/level.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Level level = JsonUtility.FromJson<Level>(json);
            return Convert.ToInt32(level.level);
        }
        else
        {
            return 0;
        }
    }
    public void SendLevel()
    {
        number ++;
        if(number ==1)
        {
            if(ConvertLevelJson()<SceneManager.GetActiveScene().buildIndex)
            {
                Level level = new Level();
                level.level = (SceneManager.GetActiveScene().buildIndex).ToString();
                string json = JsonUtility.ToJson(level);
                File.WriteAllText(Application.persistentDataPath+"/level.json",json);   
            }
        }
    }
    private void FindUIManager()
    {
        uIManager=GameObject.Find("UI Manager").GetComponent<UIManager>();
    }
    private void FindCubeManager()
    {
        cubeManager=GameObject.Find("Cube Manager").GetComponent<CubeManager>();
    }
}
