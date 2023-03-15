using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    // Start is called before the first frame update
    
    public Sprite icon = null;
    new public string name = "New Item";
    
}
    