using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position + new Vector3(6,TargetsCountY()/5,TargetsCountZ()),Time.deltaTime);
    }
    private int TargetsCountY()
    {
        int targetsCount = GameObject.Find("Main Manager").GetComponent<MainManager>().targets.Count;
        if(targetsCount<5)
        {
            return 20;
        }
        else
        {
            return 15;
        }
    }
    private int TargetsCountZ()
    {
        int targetsCount = GameObject.Find("Main Manager").GetComponent<MainManager>().targets.Count;
        if(targetsCount<=5)
        {
            return -4;
        }
        else if (targetsCount>5 && targetsCount<10)
        {
            return -8;
        }
        else
        {
            return -12 ;
        }
    }
}
