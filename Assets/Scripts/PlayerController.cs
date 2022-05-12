using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float forwardSpeed;
    private float horizontalInput;
    private float rightBarrier = 4.5f;

    private float leftBarrier = -4.5f;
    public bool gameIsStopped=false;
    public bool gameIsStoppedForUI = false;
    void Start()
    {
        
    }

    void Update()
    {
        if(gameIsStopped == false && gameIsStoppedForUI ==false)
        {
            moveHorizontal();
            moveForward();
        }
    }

    private void moveHorizontal()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*horizontalInput*turnSpeed*Time.deltaTime);
        roadBorder();
    }
    private void moveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    private void roadBorder()
    {
        if(transform.position.x > rightBarrier)
        {
            transform.position = new Vector3(rightBarrier,transform.position.y,transform.position.z);
        }
        else if (transform.position.x <leftBarrier)
        {
            transform.position = new Vector3(leftBarrier,transform.position.y,transform.position.z);
        }
    }
    public void StartPlayerRunAnimation()
    {
        GetComponent<Animator>().SetFloat("Speed_f",0.6f);
    }
    public void StopPlayerRunAnimation()
    {
        GetComponent<Animator>().SetFloat("Speed_f",0f);
    }
    public void DeadAnimation()
    {
        GetComponent<Animator>().SetBool("Death_b",true);
    }   
}
