using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float forwardSpeed;
    Vector3 firstPos,endPos;
    private float horizontalInput;
    private float rightBarrier = 4.5f;
    private float mouseSpeed = 1f;
    private float leftBarrier = -4.5f;
    public bool gameIsStopped=false;
    public bool gameIsStoppedForUI = false;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && gameIsStopped == false && gameIsStoppedForUI ==false)
        {
            firstPos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0) && gameIsStopped == false && gameIsStoppedForUI ==false)
        {
            endPos = Input.mousePosition;

            float farkX = endPos.x - firstPos.x;
            transform.Translate(farkX * Time.deltaTime * mouseSpeed / 100,0f,0f);
        }
        if(Input.GetMouseButtonUp(0) && gameIsStopped == false && gameIsStoppedForUI ==false)
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }

        //KeyboardControl
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
        GetComponent<Animator>().SetBool("IsRuning",true);
    }
    public void StopPlayerRunAnimation()
    {
        GetComponent<Animator>().SetBool("IsRuning",false);
    }
    public void DeadAnimation()
    {
        GetComponent<Animator>().SetBool("IsDead",true);
    }
}