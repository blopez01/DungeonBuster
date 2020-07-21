using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarUI : MonoBehaviour
{
    public Stats sPlayerStats;
    public Image iBar;
    public const int iMaxEnergy = 100;

    void Update()
    {
        iBar.fillAmount = EnergyNormalized();
    }
    private float EnergyNormalized()
    {
        return sPlayerStats.fHealth / iMaxEnergy;
    }
}
