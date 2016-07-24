using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public float attack = 0f;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.monster || col.tag == Tags.boss)
        {
            col.GetComponent<AttackDamage>().TakeDamage(attack);
        }
    }

    public void Shoot(float attack)
    {
        this.attack = attack;
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        Destroy(gameObject, 2.0f);
    }
}
