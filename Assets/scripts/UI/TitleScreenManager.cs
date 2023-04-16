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
    public GameObject buttonCredit;

    public CanvasGroup canvasGroup;
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
    public void goBack()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        EventSystem.current.SetSelectedGameObject(button);

    }
    public void toCredit()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        EventSystem.current.SetSelectedGameObject(buttonCredit);
        
    }
}
