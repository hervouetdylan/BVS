using System.Collections.Generic;
using UnityEngine;

public class InventoryChest : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryChest instance;
    public InventoryScript instanceInventaire;
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    public List<Item> items = new List<Item>();

    public int size = 20;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instance as once are use");
        }
        else
        {
            instance = this;
        }
        instanceInventaire = InventoryScript.instance;
        items = instanceInventaire.items;
    }
    

    // Start is called before the first frame update
    public void Add(Item item)
    {
        if (items.Count <= 20)
        {
            items.Add(item);
            if (OnItemChangedCallBack != null)
                OnItemChangedCallBack.Invoke();
        }
        else
        {
            Debug.Log("Trop d'item dans l'inventaire");
        }
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallBack != null)
            OnItemChangedCallBack.Invoke();
    }
}
