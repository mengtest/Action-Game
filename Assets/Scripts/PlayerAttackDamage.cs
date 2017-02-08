using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttackDamage : AttackDamage
{
    public float attackB = 80.0f;
    public float attackRange = 100.0f;
    public float attackGun = 500.0f;
    public float gunDistance = 5.0f;
    public GameObject bullet;
    public Transform bulletPoint;
    public AudioClip swordClip;
    public AudioClip gunClip;

    public void AttackA()
    {
        GameObject enemy = Enemy(attackDistance);  //离主角最近的敌人

        if (enemy != null)
        {
            Vector3 targetPosition = enemy.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            enemy.GetComponent<AttackDamage>().TakeDamage(normalAttack);
        }
        AudioSource.PlayClipAtPoint(swordClip, transform.position, 0.25f);
    }

    public void AttackB()
    {
        GameObject enemy = Enemy(attackDistance);  //离主角最近的敌人

        if (enemy != null)
        {
            Vector3 targetPosition = enemy.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            enemy.GetComponent<AttackDamage>().TakeDamage(attackB);
        }
        AudioSource.PlayClipAtPoint(swordClip, transform.position, 0.25f);
    }

    public void AttackRange()
    {
        List<GameObject> enemyList = EnemyList();  //目标距离内的敌人

        if (enemyList != null)
        {
            foreach (GameObject go in enemyList)
            {
                go.GetComponent<AttackDamage>().TakeDamage(attackRange);
            }
        }
        AudioSource.PlayClipAtPoint(swordClip, transform.position, 0.25f);
    }

    public void AttackGun()
    {
        GameObject enemy = Enemy(gunDistance);  //离主角最近的敌人

        if (enemy != null)
        {
            Vector3 targetPosition = enemy.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }

        GameObject go = (GameObject)Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        go.GetComponent<Bullet>().Shoot(attackGun);
        AudioSource.PlayClipAtPoint(gunClip, transform.position, 0.25f);
    }

    GameObject Enemy(float dist)
    {
        GameObject enemy = null;
        foreach (GameObject go in SpawnManager.instance.enemyList)
        {
            float distanceTemp = Vector3.Distance(transform.position, go.transform.position);
            if (distanceTemp < dist)
            {
                enemy = go;
                dist = distanceTemp;
            }
        }
        return enemy;
    }

    List<GameObject> EnemyList()
    {
        List<GameObject> enemyList = new List<GameObject>();
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager.instance.enemyList)
        {
            float distanceTemp = Vector3.Distance(transform.position, go.transform.position);
            if (distanceTemp < distance)
            {
                enemyList.Add(go);
            }
        }
        return enemyList;
    }
}
