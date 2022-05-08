using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private MainManager mainManager;
    private SpawnManager spawnManager;
    private PlayerController playerController;
    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private bool imOnTheWall=false;
    private float distanceY;
    private bool gameIsStarted=false;
    private void Start() 
    {
        FindGameObjectScripts();

        distanceY = mainManager.distanceY;
        distanceY = -distanceY;

        playerController.StopPlayerRunAnimation();
        playerController.gameIsStopped = true;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(gameIsStarted ==false)
            {
                scoreManager.pressSpaceBar.gameObject.SetActive(false);
                playerController.StartPlayerRunAnimation();
                playerController.gameIsStopped = false;
                gameIsStarted =true;
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Target Cube")
        {
            UpdateScore();

            SetParentToBaseCube(other);
    
            AddTargetInListAndSetGatheredTrue(other);

            SetDistanceBetweenCubes(other);
            
            SetHeightToPlayer(); 

            UpgradeSoundTargetCount();
        }
        if(other.gameObject.tag == "Wall")
        {
            if((other.transform.localScale.y)>mainManager.targets.Count && imOnTheWall ==false)
            {
                playerController.gameIsStopped = true;
                GameEndSoundAndAnimation();
                SendScore();
            }
            else if (imOnTheWall == false)
            {
                soundManager.DownSound();
                imOnTheWall =true;
                for(int i =TargetsCount()-1;i>=TargetsCount()-Mathf.FloorToInt(other.gameObject.transform.localScale.y);i--)
                {
                    Destroy(gameObject.transform.GetChild(i).gameObject);
                }
                mainManager.targets.RemoveRange(0,Mathf.FloorToInt(other.gameObject.transform.localScale.y));
                player.transform.position = player.transform.position + new Vector3 (0,Mathf.FloorToInt(other.gameObject.transform.localScale.y)*distanceY,0);
            }
        }
        else
        {
            imOnTheWall =false;
        }
    }
    private void UpgradeSoundTargetCount()
    {
        if(TargetsCount()==5)
        {
            soundManager.UpgradeSound();
        }
        else if(TargetsCount()==10)
        {
            soundManager.UpgradeSound();
        }
        else
        {
            soundManager.CubeTakedSound();
        }
    }
    private int TargetsCount()
    {
        return mainManager.targets.Count;
    }

    private void SetParentToBaseCube(Collider other)
    {
        other.gameObject.transform.parent = gameObject.transform;
    }
    private void GameEndSoundAndAnimation()
    {
        soundManager.GameIsStoppedSound();
        playerController.DeadAnimation();
    }

    private void AddTargetInListAndSetGatheredTrue(Collider other)
    {
        mainManager.addTargetToList(other.gameObject);
    }

    private void SetDistanceBetweenCubes(Collider other)
    {
        other.gameObject.transform.position = gameObject.transform.position + new Vector3(0,distanceY*TargetsCount(),0);
    }
    private void SetHeightToPlayer()
    {
        player.transform.position = player.transform.position + new Vector3 (0,-distanceY,0); 
    }
    private void FindGameObjectScripts()
    {
        mainManager = GameObject.Find("Main Manager").GetComponent<MainManager>();

        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();

        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
    }
    private void UpdateScore()
    {
        scoreManager.UpdateScorePerCube();
    }
    private void SendScore()
    {
        scoreManager.SendScoreToSaveFile();
    }
}
