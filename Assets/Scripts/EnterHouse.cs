using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player") // Si le tag de l'objet est "Player"
        {
            SceneManager.LoadScene("EnterHouse"); // Charge la scène "EnterHouse"
        }
    }
}
