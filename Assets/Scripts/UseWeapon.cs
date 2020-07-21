using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UseWeapon : MonoBehaviour
{
    public float fDamage;
    public float fSpeed;
    public float fRange;
    public float fKnockback;
    public float fDurability;

    private float fNextSwing = 0f;

    public GameObject player;
    public Camera cam;
    public Animator aPlayerAnim;
    // Start is called before the first frame update

    void Awake()
    {
        player = GameObject.Find("Player");
        aPlayerAnim = player.GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= fNextSwing)
        {
            fNextSwing = Time.time + fSpeed;
            Swing();
        }
    }

    void Swing ()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, fRange))
        {
            aPlayerAnim.Play("Attack"); //add different random animations
            Stats stats = hit.transform.GetComponent<Stats>();
            if (stats != null)
            {
                stats.TakeDamage(fDamage);
                fDurability--;
                if (fDurability == 0)
                {
                    //remove from player inventory
                    //Destroy(gameObject);
                }
            }

            if (hit.rigidbody != null)
            {
                NavMeshAgent nav = hit.transform.GetComponent<NavMeshAgent>();
                nav.enabled = false;
                Vector3 vPush = -hit.normal;
                vPush.y = 0.8f;
                hit.rigidbody.AddForce(vPush * fKnockback);
            }
        }

    }
}
