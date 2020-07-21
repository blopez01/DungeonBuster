using UnityEngine;

public class Stats : MonoBehaviour
{
    public const float fMoveSpeedNormal = 10f;
    public const float fJumpHeightNormal = 2f;

    public float fHealth;
    public float fDamage;
    public float fMoveSpeed = 10f;
    public float fJumpHeight = 2f;

    public bool bSpeedBuffed = false;
    public bool bJumpBuffed = false;

    public bool bHasKey = false;

    public void TakeDamage (float fDmgAmount)
    {
        fHealth -= fDmgAmount;
        if (fHealth <= 0f)
        {
            if (this.gameObject.tag == "Player")
            {
                this.gameObject.GetComponent<PlayerMove>().enabled = false;
            }
            Kill();
            Debug.Log(gameObject + " has died.");
        }
        Debug.Log(gameObject + " took " + fDmgAmount + " damage, " + fHealth + " remaining.");
    }

    void Kill ()
    {
        //ragdoll??
        Destroy(gameObject);
    }

    public void AddHealth(float fHPAdded)
    {
        if (fHPAdded + fHealth > 100)
        {
            fHPAdded = 100 - fHealth;
        }
        fHealth += fHPAdded;
    }

    void Update()
    {
        if (this.transform.position.y < -10)
        {
            Kill();
        }
    }

    public bool SpeedBuff()
    {
        if (bSpeedBuffed)
            fMoveSpeed = fMoveSpeed * 2;
        else
            fMoveSpeed = fMoveSpeedNormal;
        return bSpeedBuffed;
    }

    public bool JumpBuff()
    {
        if (bJumpBuffed)
            fJumpHeight = fJumpHeight * 2;
        else
            fJumpHeight = fJumpHeightNormal;
        return bJumpBuffed;
    }
}
