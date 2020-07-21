using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class InformativeUI : MonoBehaviour
{
    public GameController gcScript;
    public TMP_Text tWaveNum;
    public TMP_Text tRemainingEnemy;
    public TMP_Text tGameOverText;
    public TMP_Text tRestartingText;
    public Stats sPlayerStats;

    // Update is called once per frame
    void Update()
    {
        if (sPlayerStats.fHealth <= 0)
        {
            tGameOverText.enabled = true;
            tRestartingText.enabled = true;
            StartCoroutine(Restart());
        }
    }
    IEnumerator Restart()
    {
        tGameOverText.enabled = true;
        tRestartingText.enabled = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameScene1");
    }
}
