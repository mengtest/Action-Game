using UnityEngine;
using System.Collections;

public class MonsterAttackDamage : AttackDamage
{
    private Transform player;

    void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    public void MonAttack()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < attackDistance)
        {
            player.GetComponent<AttackDamage>().TakeDamage(normalAttack);
        }
    }
}
