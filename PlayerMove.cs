using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public bool isCanWalk = false;
    public Vector3 targetDir = Vector3.zero;
    private CharacterController cc;
    private Animator animator;
    private float speed = 5.0f;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isCanWalk)
        {
            animator.SetBool("Walk", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
            {
                transform.LookAt(targetDir + transform.position);
                cc.SimpleMove(transform.forward * speed);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
