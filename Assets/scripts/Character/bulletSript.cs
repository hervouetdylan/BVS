using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSript : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D col;
    private Transform Player;
    void Start()
    {

        Player = FindObjectOfType<Mouvements>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Player.position);
        if (this != null && Player != null && Vector2.Distance(Player.position, this.transform.position) > 50)
        {
            Destroy(this.gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            //TODO tuer l'enemy
            //collision.gameObject.
            Destroy(this.gameObject);

        }
    }
}
