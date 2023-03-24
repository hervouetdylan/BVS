using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private IState currentState;

    private Transform target;

    private bool rangeAttack = false;

    public bool RangeAttack
    {
        get{return rangeAttack;}
        set{rangeAttack = value;}
    }

    public Animator animator;

    [SerializeField]
    private float speed;

    public float Speed
    {
        get{return speed;}
        set{speed = value;}
    }
    
    [SerializeField]
    private Vector2 direction;

    public Vector2 Direction
    {
        get{return direction;}
        set{direction = value;}
    }


    public Transform Target
    {
        get{return target;}
        set{target = value;}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void Awake()
    {
        ChangeState(new IdleState());
    }

    protected void Update()
    {
        currentState.Update();
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(10);
        }
    }
}
