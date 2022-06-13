using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSettingsMenu : MonoBehaviour
{
    public static PrefabSettingsMenu prefabSettingsMenuInstance;
    private float rotateSpeed = 30.0f;
    [SerializeField]
    private GameObject mainPrefab;
    private void Start() {
        PlayerStopAnimation();
    }
    private void Update() {
        RotatePlayerPreFab();
    }
    private void RotatePlayerPreFab()
    {
        transform.Rotate(new Vector3(transform.rotation.x,2,transform.rotation.z)*Time.deltaTime*rotateSpeed);
    }
    public void PlayerStopAnimation()
    {
        gameObject.GetComponent<Animator>().SetBool("IsRuning",false);
    }
    
    private void Awake() {
        if(prefabSettingsMenuInstance ==null)
        {
            prefabSettingsMenuInstance=this;
            DontDestroyOnLoad(gameObject);
        }
        else if(prefabSettingsMenuInstance !=this) 
        {
            Destroy(gameObject);
        } 
    }
    
}
