using UnityEngine;
using System.Collections;

public class AttackDamage : MonoBehaviour
{
    public float hp = 100.0f;
    public float normalAttack = 50.0f;
    public float attackDistance = 1.0f;
    public AudioClip deathClip;
    public GameObject hiMonster;
    public GameObject hiBoss;
    public GameObject dualSowrd;
    public GameObject gun;
    public UISprite lose;
    private Animator animator;

    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }
        if (hp > 0)
        {
            if (tag == Tags.monster || tag == Tags.boss)
            {
                int random = Random.Range(0, 10);
                if (random >= 5)
                {
                    animator.SetTrigger("Damage");
                }
            }
            else if (tag == Tags.player)
            {
                int random = Random.Range(0, 10);
                if (random == 9)
                {
                    animator.SetTrigger("Damage");
                }
            }
        }
        else
        {
            animator.SetTrigger("Death");
            if (tag == Tags.monster || tag == Tags.boss)
            {
                ShowUI.instance.count++;
                SpawnManager.instance.enemyList.Remove(gameObject);
                GetComponent<CharacterController>().enabled = false;
                Destroy(gameObject, 2.0f);
                Award();
            }
            else if (tag == Tags.player)
            {
                lose.gameObject.SetActive(true);
            }
            AudioSource.PlayClipAtPoint(deathClip, transform.position, 0.25f);
        }

        //实例化特效
        if (tag == Tags.monster)
        {
            Instantiate(hiMonster, transform.position + Vector3.up, transform.rotation);
        }
        else if (tag == Tags.boss)
        {
            Instantiate(hiBoss, transform.position + Vector3.up, transform.rotation);
        }
    }

    void Award()
    {
        int count = Random.Range(1, 3);
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, 5);
            if (index == 4)
            {
                Instantiate(gun, transform.position + Vector3.up, Quaternion.identity);
            }
            else
            {
                Instantiate(dualSowrd, transform.position + Vector3.up, Quaternion.identity);
            }
        }
    }
}
