using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject message;
    public GameObject objMessage;
    public Stats playerStats;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            message.SetActive(true);
            Animator doorAnim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.F))
            {
                doorAnim.SetTrigger("OpenClose");
            }
            
        }
        else if (other.tag == "BossDoor")
        {
            message.SetActive(true);
            Animator doorAnim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.F) && playerStats.bHasKey == true)
            {
                doorAnim.SetTrigger("OpenClose");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door" || other.tag == "BossDoor")
        {
            message.SetActive(false);
        }
    }
}
