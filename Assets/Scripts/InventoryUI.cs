using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform tInventoryParent;
    PlayerInventory pInventory;
    InventorySlot[] slotsArr;
    // Start is called before the first frame update
    void Start()
    {
        pInventory = PlayerInventory.instance;
        pInventory.onItemChangeUpdate += UpdateUI;

        slotsArr = tInventoryParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI ()
    {
        for (int i = 0; i < slotsArr.Length; i++)
        {
            if (i < pInventory.lItems.Count)
            {
                slotsArr[i].AddItem(pInventory.lItems[i]);
            }
        }
    }
}
