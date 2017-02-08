using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    private float speed = 10.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        offset = player.position - transform.position;
    }

    void Update()
    {
        Vector3 targetPosition = player.position - offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        //Quaternion targetRotation = Quaternion.LookRotation(offset);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
    }
}
