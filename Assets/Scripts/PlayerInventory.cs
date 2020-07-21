using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    void Awake()
    {
        instance = this;
    }
    public delegate void OnItemChange();
    public OnItemChange onItemChangeUpdate;

    public int iInventorySpace = 3;

    public List<Item> lItems = new List<Item>();

    void Update()
    {

    }
    public bool Add (Item iItem)
    {
        if (lItems.Count >=iInventorySpace)
        {
            //full inventory
            return false;
        }
        lItems.Add(iItem);
        if (onItemChangeUpdate != null)
            onItemChangeUpdate.Invoke();
        return true;
    }
    public void Remove (Item iItem)
    {
        lItems.Remove(iItem);
        if (onItemChangeUpdate != null)
            onItemChangeUpdate.Invoke();
    }
}
