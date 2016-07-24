using UnityEngine;
using System.Collections;

public class BossAttackDamage : AttackDamage
{
    public AudioClip attackClip;
    private Transform player;

    void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    public void Attack1()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < attackDistance)
        {
            player.GetComponent<AttackDamage>().TakeDamage(normalAttack);
        }
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 0.5f);
    }

    public void Attack2()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < attackDistance)
        {
            player.GetComponent<AttackDamage>().TakeDamage(normalAttack);
        }
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 0.5f);
    }
}
