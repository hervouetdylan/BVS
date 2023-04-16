using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string NomDeScene;

    public GameObject button;

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(button);

    }
    public void AllezAuNiveau(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Quit()
    {
#if !UNITY_WEBGL
        Application.Quit();
#endif
    }
}
