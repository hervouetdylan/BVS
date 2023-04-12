using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
Rigidbody2D rb;
    public float moveSpeed;
    Vector2 moveDir;
    // public Animator animator;
    Vector2 mousePos;
    public GameObject prefab;
    public Camera mainCam;

    public void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        InputManagement();


        // animator.SetFloat("Horizontal",moveDir.x);
        // animator.SetFloat("Vertical",moveDir.y);
        // animator.SetFloat("Speed", moveDir.sqrMagnitude);


        // if (Input.GetButtonDown("Fire1"))
        // {
        //     mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //     mousePos.x = (float)Math.Round(mousePos.x);
        //     mousePos.y = (float)Math.Round(mousePos.y);

        //     Debug.Log(mousePos.x);
        //     Debug.Log(mousePos.y);
        //     Instantiate(prefab, mousePos, transform.rotation);


        // }

    }
    void FixedUpdate(){
        rb.velocity = new Vector2(moveDir.x * moveSpeed,moveDir.y * moveSpeed);
    }

    public void InputManagement(){
        float moveX =0f; 
        float moveY =0f; ;
        if (Input.GetKey(KeyCode.Z))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY=-1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            moveX=-1f;
        }

        moveDir = new Vector2(moveX,moveY).normalized;
    }

}
