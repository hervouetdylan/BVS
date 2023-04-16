using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup[] menus;
    private GameObject[] keybindButtons;
    [SerializeField]
    private GameObject[] buttons;
    private Mouvements player;
    private bool isEditor;
    private bool isPause;
    private bool inAction = false;

    public bool IsEditor
    {
        get { return isEditor; }
        set { isEditor = value; }
    }

    public bool InAction
    {
        get { return inAction; }
        set { inAction = value; }
    }

    public bool IsPause
    {
        get { return isPause; }
        set { isPause = value; }
    }
    private static UIManager instance;

    public static UIManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        keybindButtons = GameObject.FindGameObjectsWithTag("Keybind");
        player = FindObjectOfType<Mouvements>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V) && !IsPause)
        {
            menus[3].alpha = menus[3].alpha > 0 ? 0 : 1;
            menus[3].blocksRaycasts = menus[3].blocksRaycasts == true ? false : true;
            IsEditor = IsEditor == true ? false : true;
        }
        if (Input.GetKeyDown(KeyCode.E) && !IsPause)
        {
            menus[2].alpha = menus[2].alpha > 0 ? 0 : 1;
            menus[2].blocksRaycasts = menus[2].blocksRaycasts == true ? false : true;
            IsEditor = IsEditor == true ? false : true;
        }
    }
    public void enterMenu()
    {
        if (menus[0].alpha == 0)
        {
            OpenClose(menus[0]);
            Time.timeScale = 0;
            IsPause = true;
            EventSystem.current.SetSelectedGameObject(buttons[0]);

        }
        else
        {
            CloseAll();
            IsPause = false;
        }
    }
    public void OpenClose(CanvasGroup canvasGroup)
    {
        CloseAll();
        Time.timeScale = 0;
        InAction = true;

        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
        Debug.Log("UI :" + InAction);
    }

    public void UpdateKeyText(string key, KeyCode code)
    {
        Text tmp = Array.Find(keybindButtons, x => x.name == key).GetComponentInChildren<Text>();
        tmp.text = code.ToString();
    }


    public void CloseAll()
    {
        Time.timeScale = 1;
        InAction = false;

        foreach (CanvasGroup canvas in menus)
        {
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
        }
    }


    public void TitleScreen()
        {
            SceneManager.LoadScene("TitleScreen"); // Charge la scène "ScenePrincipale"
        }
}
