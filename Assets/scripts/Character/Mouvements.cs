using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Mouvements : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float moveSpeed;
    Vector2 moveDir;
    public Animator animator;
    Vector2 mousePos;
    public GameObject prefab;
    public Camera mainCam;
    public UIManager UIManager;
    private Vector2 lastDir;
    public bool isDead = false;
    public static Mouvements instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'un instance de Mouvements dans la scène");
            return;
        }
        instance = this;
    }

    public void Start(){
        rb = GetComponent<Rigidbody2D>();

    }

    void Update(){
        if(!isDead){
            InputMovement();
            InputAction();
        }
        

    }
    void FixedUpdate(){
        rb.velocity = new Vector2(moveDir.x*moveSpeed,moveDir.y*moveSpeed);
        animator.SetFloat("Horizontal",lastDir.x);
        animator.SetFloat("Vertical",lastDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);

    }

    public void InputMovement(){
        
        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["UP"]))
        {
            moveDir.y = 1f;
        }
        else if (Input.GetKey(KeybindManager.MyInstance.Keybinds["DOWN"]))
        {
            moveDir.y=-1f;
        }
        else{
            moveDir.y=0f;
        }
        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["RIGHT"]))
        {
            moveDir.x = 1f;
        }
        else if (Input.GetKey(KeybindManager.MyInstance.Keybinds["LEFT"]))
        {
            moveDir.x=-1f;
        }
        else{
            moveDir.x=0f;
        }
        if (moveDir.x != 0 || moveDir.y != 0)
        {
            lastDir = moveDir;
        }
    }

    public void InputAction()
    {
        if (UIManager.IsEditor){
            if (Input.GetButtonDown("Fire1"))
            {
                mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if(!hit.collider){
                    mousePos.x = (float)Math.Round(mousePos.x);
                    mousePos.y = (float)Math.Round(mousePos.y);
                    Instantiate(prefab, mousePos, transform.rotation);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider != null && hit.collider.gameObject.tag== "Build") {
                    Debug.Log(hit.collider.gameObject.name);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector2 Dir = new Vector2(rb.position.x + lastDir.x, rb.position.y + lastDir.y);
            RaycastHit2D hit = Physics2D.Raycast(Dir, Vector2.zero);
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "Chest(Clone)")
            {
                // UIManager.OpenClose();
            }
        }
        

    }
}
