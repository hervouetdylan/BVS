using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour
{
    
    [SerializeField]
    private CanvasGroup[] menus;
    private GameObject[] keybindButtons;

    private bool isEditor;
    private bool isPause;

    public bool IsEditor
    {
        get{return isEditor;}
        set{isEditor = value;}
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
            if (instance == null){
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
        keybindButtons=GameObject.FindGameObjectsWithTag("Keybind");

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V) && !IsPause)
        {
            OpenClose(menus[3]);
            IsEditor = IsEditor == true ? false:true;
        }
        if (Input.GetKeyDown(KeyCode.E) && !IsPause)
        {
            OpenClose(menus[2]);
        }
    }
    public void enterMenu()
    {
        if (menus[0].alpha == 0)
        {
            OpenSingle(menus[0]);
            Time.timeScale = 0;
            IsPause = IsPause == true ? false : true;
            EventSystem.current.SetSelectedGameObject(menus[0].gameObject);

        }
        else
        {
            CloseAll();
            Time.timeScale = 1;
            IsPause = IsPause == true ? false : true;

        }
    }
    public void OpenClose(CanvasGroup canvasGroup){
        canvasGroup.alpha = canvasGroup.alpha>0 ? 0 : 1;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
    }

    public void UpdateKeyText(string key, KeyCode code)
    {
        Text tmp = Array.Find(keybindButtons, x=> x.name == key).GetComponentInChildren<Text>();
        tmp.text = code.ToString();
    }

    public void OpenSingle(CanvasGroup canvasGroup)
    {
        foreach (CanvasGroup canvas in menus)
        {
            CloseSingle(canvas);    
        }
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0:1;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false:true;
    }

    public void CloseSingle(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;

    }

    public void CloseAll()
    {
        foreach (CanvasGroup canvas in menus)
        {
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
        }
    }
}
