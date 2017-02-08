using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public float speed = 2.0f;
    public float attackDistance = 2.0f;
    public float attackTime = 2.0f;
    private float attackTimer = 0;
    private CharacterController cc;
    private PlayerAttackDamage pad;
    private Animator animator;
    private Transform player;
    private AttackDamage ad;

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
                int random = Random.Range(1, 3);
                animator.SetTrigger("Attack0" + random);
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
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("BossRun01"))
            {
                cc.SimpleMove(transform.forward * speed);
            }
        }
    }
}
