using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public GameObject tPlayer;
    public NavMeshAgent nAgent;
    public Animator aEnemyAnim;
    public Rigidbody rb;
    public Transform tGrounded;
    public LayerMask lmGroundMask;
    public BossAttack bossAttack;

    public float fGroundSpace = 0.5f;
    public bool bIsGrounded;

    public float fAlertRad;
    Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        nAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("Wait", 1f, 1f);
        tPlayer = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = tPlayer.transform;
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= fAlertRad)
        {

            nAgent.SetDestination(playerTransform.position);
            aEnemyAnim.SetInteger("Walk Forward", 1);
            if (nAgent.remainingDistance < 7f)
            {
                aEnemyAnim.SetInteger("Walk Forward", 0);
                bossAttack.Attack();
            }
            FaceTarget();
        }
        else
        {
            nAgent.SetDestination(transform.position);
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void Wait()
    {
        bIsGrounded = Physics.CheckSphere(tGrounded.position, fGroundSpace, lmGroundMask);
        if (bIsGrounded)
        {
            nAgent.enabled = true;
        }
        else
        {
            nAgent.enabled = false;
            aEnemyAnim.SetInteger("RunForward", 0);
        }
    }
}
