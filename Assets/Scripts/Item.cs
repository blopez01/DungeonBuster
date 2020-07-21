using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
public class Item : ScriptableObject
{
    new public string sName = "New Item";
    public Sprite spIcon = null;
    public float fDmg;
    public float fRng;
    public float fSpd;
    public float fKbk;
    public float fDur;
}
