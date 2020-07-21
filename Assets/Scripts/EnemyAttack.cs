using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject tPlayer;
    public Collider collider;
    public Animator aEnemyAnim;
    public Stats targetStats;
    public Stats selfStats;

    void Start()
    {
        tPlayer = GameObject.FindGameObjectWithTag("Player");
        targetStats = tPlayer.GetComponent<Stats>();
    }
    public void Attack()
    {

        aEnemyAnim.SetTrigger("Attack");

    }
    public void hitStart ()
    {
        collider.enabled = true;
    }
    public void hitEnd()
    {
        collider.enabled = false;
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("hit");
        if (collider.gameObject.tag == "Player")
        {
            targetStats.TakeDamage(selfStats.fDamage);
            hitEnd();
        }
    }
}
