using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mouvements : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float moveSpeed;
    Vector2 moveDir;
    private Vector2 lastDir;

    public Animator animator;
    Vector2 mousePos;
    public GameObject prefab;
    public Camera mainCam;
    public UIManager UIManager;
    public GameObject bullet;
    Item item;
    private float bulletSpeed = 4;
    InventoryScript inventaire;
    UIManager ui;
    public bool isDead = false;
    
    private void Awake()
    {
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inventaire = InventoryScript.instance;
        ui = FindObjectOfType<UIManager>();
        Time.timeScale = 1;
    }

    void Update()
    {



    }
    void FixedUpdate()
    {
        if (!ui.InAction && !isDead)
        {
            rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        }
        animator.SetFloat("Horizontal", lastDir.x);
        animator.SetFloat("Vertical", lastDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);

    }


    public void OnMove(InputValue value)
    {

        moveDir = value.Get<Vector2>();
        if (moveDir.x != 0 || moveDir.y != 0)
        {
            lastDir = moveDir;
        }

    }

    public void OnMenu()
    {
        ui.enterMenu();
    }
    public void OnFire()
    {
        if (!ui.InAction && !isDead)
        {

            if (UIManager.IsEditor)
            {
                mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (!hit.collider)
                {
                    mousePos.x = (float)Math.Round(mousePos.x);
                    mousePos.y = (float)Math.Round(mousePos.y);
                    Instantiate(prefab, mousePos, transform.rotation);
                }
            }
            else
            {
                int bulletx = 1;
                int degrees = 0;
                if (lastDir.x > 0) lastDir.x = 1;
                else if (lastDir.x < 0) lastDir.x = -1;
                else lastDir.x = 0;
                if (lastDir.y > 0.4) lastDir.y = 1;
                else if (lastDir.y < -0.4) lastDir.y = -1;
                else lastDir.y = 0;

                if (Math.Round(lastDir.y) != 0)
                {
                    degrees = 90;
                    bulletx = 0;
                }


                Vector2 Dir = new Vector2(rb.position.x + lastDir.x / 10 * bulletx, rb.position.y + lastDir.y / 8);

                GameObject bulletObj = Instantiate(bullet, Dir, transform.rotation);

                //Debug.Log(lastDir.x + " " + lastDir.y);
                bulletObj.transform.rotation = Quaternion.Euler(Vector3.forward * degrees);
                Rigidbody2D rbBullet = bulletObj.GetComponent<Rigidbody2D>();
                rbBullet.velocity = new Vector2(Convert.ToSingle(Math.Round(lastDir.x)) * bulletSpeed * bulletx, Convert.ToSingle(Math.Round((lastDir.y) * bulletSpeed)));
            }
        }

    }
    public void OnLeftTrigger()
    {
        if (Input.GetMouseButtonDown(1))
        {

            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider != null && hit.collider.gameObject.tag == "Build")
            {
                Debug.Log(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }
    public void OnInteraction()
    {
        if (!ui.InAction && !isDead)
        {


            if (lastDir.x > 0) lastDir.x = 1;
            else if (lastDir.x < 0) lastDir.x = -1;
            else lastDir.x = 0;
            if (lastDir.y > 0.4) lastDir.y = 1;
            else if (lastDir.y < -0.4) lastDir.y = -1;
            else lastDir.y = 0;
            Vector2 Dir = new Vector2(rb.position.x + lastDir.x / 10, rb.position.y + lastDir.y / 8);
            RaycastHit2D hit = Physics2D.Raycast(Dir, Vector2.zero);
            if (hit.collider.gameObject.tag != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            if (hit.collider.gameObject.tag == "Chest")
            {
                item = hit.collider.gameObject.GetComponent<ChestScript>().item;
                inventaire.Add(item);
                hit.collider.gameObject.GetComponent<ChestScript>().animator.Play("Coffre");

            }
            else if (hit.collider.gameObject.tag == "Shop")
            {
                hit.collider.gameObject.GetComponent<Shop>().OpenShop();
            }
            else if (hit.collider.gameObject.tag == "PNG")
            {
                hit.collider.gameObject.GetComponent<TriggerDialogue>().DialogueTrigger();
            }
        }
    }
}
