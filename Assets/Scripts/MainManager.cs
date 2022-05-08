using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public float distanceY = 1.1f;
    public List<GameObject> targets = new List<GameObject>();
    public void addTargetToList(GameObject targetObject)
    {
        targets.Add(targetObject);
    }
}