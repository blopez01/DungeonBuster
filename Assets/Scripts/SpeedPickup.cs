using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Stats>().bSpeedBuffed = true;
            collision.gameObject.GetComponent<Stats>().SpeedBuff();
            Destroy(gameObject);
        }
    }
}
