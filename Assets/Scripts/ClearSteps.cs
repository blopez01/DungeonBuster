using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSteps : MonoBehaviour
{
    public GameObject message;
    public bool bBossKilled = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (bBossKilled)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene("EndScreen");
                }
            }
            else
            {
                message.SetActive(true);
                Invoke("NotDone", 0.25f);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        message.SetActive(false);
    }
    public void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            bBossKilled = true;
        }
    }

    IEnumerator NotDone()
    {
        yield return new WaitForSeconds(3);
        message.SetActive(false);
    }
}
