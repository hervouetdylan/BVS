using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHouse : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "ExitHouse") // Si le tag de l'objet est "Player"
        {
            SceneManager.LoadScene("ScenePrincipale"); // Charge la scène "ScenePrincipale"
        }
    }
}