using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public float fRadius = 2f;
    public Transform tPlayer;
    public Item iItem;
    public GameObject hand;
    public GameObject message;
    UseWeapon uApplyStats;

    WeaponCycle cycle;

    public Vector3 vPickPosition;
    public Vector3 vPickRotation;

    void Awake ()
    {
        tPlayer = GameObject.Find("Player").transform;
        hand = GameObject.Find("Player/RPG-Character/Motion/B_Pelvis/B_Spine/B_Spine1/B_Spine2/B_R_Clavicle/B_R_UpperArm/B_R_Forearm/B_R_Hand/WeaponHolder");
        
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, fRadius);
    }

    void Update()
    {        
        if (Vector3.Distance(tPlayer.position, transform.position) < fRadius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                this.GetComponent<Rigidbody>().useGravity = false;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                bool bTaken = PlayerInventory.instance.Add(iItem);
                //add to hand
                if (bTaken)
                {
                    Debug.Log("Picked up " + iItem.name);
                    this.GetComponent<Rigidbody>().useGravity = false;
                    this.GetComponent<Rigidbody>().isKinematic = false;
                    this.GetComponent<Collider>().enabled = false;
                    transform.SetParent(hand.transform);
                    transform.localPosition = vPickPosition;
                    transform.localEulerAngles = vPickRotation;
                    cycle = transform.parent.GetComponent<WeaponCycle>();
                    uApplyStats = gameObject.GetComponent<UseWeapon>();
                    uApplyStats.fDamage = iItem.fDmg;
                    uApplyStats.fSpeed = iItem.fSpd;
                    uApplyStats.fRange = iItem.fRng;
                    uApplyStats.fKnockback = iItem.fKbk;
                    uApplyStats.fDurability = iItem.fDur;
                    cycle.SelectWeapon();
                    gameObject.GetComponent<InteractableItem>().enabled = false; //to ensure we dont pick up more than one item next time
                }
                    
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            message.SetActive(true);
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
