using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KeybindManager : MonoBehaviour
{
    private static KeybindManager instance;
    public static KeybindManager MyInstance
    {
        get
        {
            if (instance == null){
                instance = FindObjectOfType<KeybindManager>();
            }
            return instance;    
        }
    }
    
    public Dictionary<string, KeyCode> Keybinds {get;private set;}
    public Dictionary<string, KeyCode> Actionsbind {get;private set;}
    private string bindName;
    // Start is called before the first frame update
    void Start()
    {
        Keybinds = new Dictionary<string, KeyCode>();
        Actionsbind = new Dictionary<string, KeyCode>();
        BindKey("UP",KeyCode.Z);
        BindKey("DOWN",KeyCode.S);
        BindKey("LEFT",KeyCode.Q);
        BindKey("RIGHT",KeyCode.D);

        BindKey("INVENTORY",KeyCode.E);
    }

    public void BindKey(string key, KeyCode keyBind){
        Dictionary<string, KeyCode> currentDictionary = Keybinds;
        if(key.Contains("ACT"))
        {
            currentDictionary = Actionsbind;
        }
        if (!currentDictionary.ContainsKey(key))
        {
            currentDictionary.Add(key, keyBind);
            UIManager.MyInstance.UpdateKeyText(key, keyBind);
        }
        else if(currentDictionary.ContainsValue(keyBind))
        {
            string myKey = currentDictionary.FirstOrDefault(x => x.Value  == keyBind).Key;

            currentDictionary[myKey] = KeyCode.None;
            UIManager.MyInstance.UpdateKeyText(key, KeyCode.None);

        }

        currentDictionary[key] = keyBind;
        UIManager.MyInstance.UpdateKeyText(key, keyBind);
        foreach (var item in currentDictionary)
        {
            Debug.Log(item);
        }
        Debug.Log(currentDictionary);
        bindName = string.Empty;
    }
    // Update is called once per frame
    public void KeyBindOnClick(string bindName){
        this.bindName = bindName;
        
    }
    private void OnGUI()
    {
        if (bindName != string.Empty)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                BindKey(bindName, e.keyCode);
            }
        }
    }

}
