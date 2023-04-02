using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSript : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D col;
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            //TODO tuer l'enemy
            //collision.gameObject.
            Destroy(this.gameObject);

        }
    }
}
