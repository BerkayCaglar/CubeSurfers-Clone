using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainManager : MonoBehaviour
{
    public float distanceY = 1.1f;
    [SerializeField]
    private TMP_Text youWonText;
    [SerializeField]
    private TMP_Text tryAgain;
    [SerializeField]
    private GameObject ESC_Menu;
    [SerializeField]
    private GameObject postProccess;
    private PlayerController playerController;
    private bool heIsOnEscapeMenu = false;
    public List<GameObject> targets = new List<GameObject>();
    public void addTargetToList(GameObject targetObject)
    {
        targets.Add(targetObject);
    }
    public void ShowYouWon()
    {
        youWonText.gameObject.SetActive(true);
    }
    public void TryAgainShow()
    {
        tryAgain.gameObject.SetActive(true);
    }
    private void Start() 
    {
        tryAgain.gameObject.SetActive(false);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void LateUpdate() 
    {
        CheckESCButton();
    }
    private void CheckESCButton()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&heIsOnEscapeMenu == false)
        {
            ESC_Menu.gameObject.SetActive(true);
            postProccess.gameObject.SetActive(true);
            playerController.gameIsStopped=true;
            heIsOnEscapeMenu = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && heIsOnEscapeMenu == true)
        {
            ESC_Menu.gameObject.SetActive(false);
            postProccess.gameObject.SetActive(false);
            playerController.gameIsStopped=false;
            heIsOnEscapeMenu = false;
        }
    }
}