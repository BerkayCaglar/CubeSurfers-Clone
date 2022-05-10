using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainManager : MonoBehaviour
{
    public float distanceY = 1.1f;
    [SerializeField]
    private TMP_Text youWonText;
    public List<GameObject> targets = new List<GameObject>();
    public void addTargetToList(GameObject targetObject)
    {
        targets.Add(targetObject);
    }
    public void ShowYouWon()
    {
        youWonText.gameObject.SetActive(true);
    }
}