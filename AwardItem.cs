using UnityEngine;
using System.Collections;

public enum AwardType
{
    DualSword,
    Gun
}

public class AwardItem : MonoBehaviour
{
    public AwardType awardType;
    public AudioClip pickupClip;
    private Transform player;
    private float speed = 10.0f;
    private float distance = 0.5f;
    private bool isCanMove = false;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }

    void Update()
    {
        if (isCanMove)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + Vector3.up * 0.5f, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, player.position) <= distance)
            {
                player.GetComponent<PlayerAward>().GetAward(awardType);
                Destroy(gameObject);
            }
            AudioSource.PlayClipAtPoint(pickupClip, transform.position, 0.25f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.ground)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<SphereCollider>().isTrigger = true;
            GetComponent<SphereCollider>().radius = 10.0f;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.player)
        {
            isCanMove = true;
            player = col.transform;
        }
    }
}
