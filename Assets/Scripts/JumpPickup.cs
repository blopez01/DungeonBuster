using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickup : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Stats>().bJumpBuffed = true;
            collision.gameObject.GetComponent<Stats>().JumpBuff();
            Destroy(gameObject);
        }
    }
}
