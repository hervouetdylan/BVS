using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    Vector2 moveDir;
    public Animator animator;
    // Vector2 mousePos;
    // public GameObject prefab;
    // public Camera mainCam;
    // public UIManager UIManager;
    private Vector2 lastDir;

    public void Start(){
        rb = GetComponent<Rigidbody2D>();

    }

    void Update(){
        InputMovement();
        // InputAction();
        

    }
    void FixedUpdate(){
        rb.velocity = new Vector2(moveDir.x*moveSpeed,moveDir.y*moveSpeed);
        animator.SetFloat("Horizontal",lastDir.x);
        animator.SetFloat("Vertical",lastDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);

    }

    public void InputMovement(){
        // Mouvement du joueur
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        if (moveDir.x != 0){
            lastDir.x = moveDir.x;
        }
        if (moveDir.y != 0){
            lastDir.y = moveDir.y;
        }
    }

    // public void InputAction()
    // {
    //     if (UIManager.IsEditor){
    //         if (Input.GetButtonDown("Fire1"))
    //         {
    //             mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    //             RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
    //             if(!hit.collider){
    //                 mousePos.x = (float)Math.Round(mousePos.x);
    //                 mousePos.y = (float)Math.Round(mousePos.y);
    //                 Instantiate(prefab, mousePos, transform.rotation);
    //             }
    //         }
    //         if (Input.GetMouseButtonDown(1))
    //         {
    //             mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    //             RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
    //             Debug.Log(hit.collider.gameObject.name);
    //             if (hit.collider != null && hit.collider.gameObject.tag== "Build") {
    //                 Debug.Log(hit.collider.gameObject.name);
    //                 Destroy(hit.collider.gameObject);
    //             }
    //         }
    //     }
    //     if (Input.GetKeyDown(KeyCode.F))
    //     {
    //         Vector2 Dir = new Vector2(rb.position.x + lastDir.x, rb.position.y + lastDir.y);
    //         RaycastHit2D hit = Physics2D.Raycast(Dir, Vector2.zero);
    //         Debug.Log(hit.collider.gameObject.name);
    //         if (hit.collider.gameObject.name == "Chest(Clone)")
    //         {
    //             // UIManager.OpenClose();
    //         }
    //     }
        

    // }
}
