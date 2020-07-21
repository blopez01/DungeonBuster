using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpUI : MonoBehaviour
{
    public GameObject message;
    public TMP_Text objectiveText;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            message.SetActive(true);
            Stats playerStats = other.GetComponent<Stats>();
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerStats.bHasKey = true;
                message.SetActive(false);
                objectiveText.text = "Objective: Destroy the Boss";
                Destroy(gameObject);
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            message.SetActive(false);
        }
    }
}
