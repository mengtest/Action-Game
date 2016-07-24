using UnityEngine;
using System.Collections;

public class Moster : MonoBehaviour
{
    public float speed = 2.0f;
    public float attackDistance = 1.0f;
    public float attackTime = 2.0f;
    private float attackTimer = 0;
    private Transform player;
    private PlayerAttackDamage pad;
    private CharacterController cc;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        pad = player.GetComponent<PlayerAttackDamage>();
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (pad.hp <= 0)  //主角死亡
        {
            animator.SetBool("Walk", false);
            return;
        }

        Vector3 targetPosition = player.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackDistance)  //攻击范围之内并且主角没有死亡
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackTime)
            {
                animator.SetTrigger("Attack");
                attackTimer = 0;
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
        else  //攻击范围之外
        {
            attackTimer = attackTime;  //到达目标可以直接攻击
            animator.SetBool("Walk", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.SimpleMove(transform.forward * speed);
            }
        }
    }
}
