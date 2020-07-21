using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController ccController;
    public Transform tGrounded;
    public float fGroundSpace = 0.5f;
    public LayerMask lmGroundMask;
    public Stats stats;

    public Animator aPlayerAnim;

    float fMoveControl;
    float fGravity = -9.81f * 2f;

    Vector3 vVelocity;
    bool bIsGrounded;

    void Start()
    {
        fMoveControl = 10f;
    }

    void Update()
    {
        bIsGrounded = Physics.CheckSphere(tGrounded.position, fGroundSpace, lmGroundMask);

        if (bIsGrounded && vVelocity.y < 0)
            vVelocity.y = 0f;

        float fXMove = Input.GetAxis("Horizontal");
        float fZMove = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && bIsGrounded)
            vVelocity.y = Mathf.Sqrt(stats.fJumpHeight * -2f * fGravity);

        #region InputMoveSpeed
        if (Input.GetKey(KeyCode.W))
        {
            fMoveControl = this.stats.fMoveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            fMoveControl = this.stats.fMoveSpeed / 1.5f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            fMoveControl = this.stats.fMoveSpeed / 2.5f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            fMoveControl = this.stats.fMoveSpeed / 1.5f;
        }
        #endregion

        #region InputWalkAnim
        if (Input.GetKeyDown(KeyCode.W))
        {
            aPlayerAnim.SetInteger("RunForwardCondition", 1);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            aPlayerAnim.SetInteger("RunForwardCondition", 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            aPlayerAnim.SetInteger("WalkBackCondition", 1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            aPlayerAnim.SetInteger("WalkBackCondition", 0);
        }
        #endregion

        Vector3 vMove = transform.right * fXMove + transform.forward * fZMove;

        ccController.Move(vMove * fMoveControl * Time.deltaTime);

        vVelocity.y += fGravity * Time.deltaTime;

        ccController.Move(vVelocity * Time.deltaTime);
    }

}
