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
    private void Start() {
        tryAgain.gameObject.SetActive(false);
    }
}