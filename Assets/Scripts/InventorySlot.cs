using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image iIcon;
    public RectTransform rect;

    Item item;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void AddItem (Item iAdd)
    {
        item = iAdd;
        iIcon.sprite = item.spIcon;
        iIcon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        iIcon.sprite = null;
        iIcon.enabled = false;
    }

    public void RemoveFromInventory()
    {
        PlayerInventory.instance.Remove(item);
    }
}
