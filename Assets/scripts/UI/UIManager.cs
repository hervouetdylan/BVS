using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup editor;

    [SerializeField]
    private CanvasGroup inventory;
    
    [SerializeField]
    private CanvasGroup[] menus;
    private GameObject[] keybindButtons;

    private bool isEditor;

    public bool IsEditor
    {
        get{return isEditor;}
        set{isEditor = value;}
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menus[0].alpha==0){
                OpenSingle(menus[0]);
            }else{
                CloseAll();
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            OpenClose(editor);
            IsEditor = IsEditor == true ? false:true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenClose(inventory);
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
