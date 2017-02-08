using UnityEngine;
using System.Collections;

public class PlayerIcon : MonoBehaviour
{
    private Transform player;
    private Transform playerIcon;
    private float scale = 5.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        playerIcon = Minmap.instance.GetPlayerIcon();
    }

    void Update()
    {
        float y = player.eulerAngles.y;
        playerIcon.localEulerAngles = new Vector3(0, 0, -y);

        Vector3 offset = player.position;
        offset *= scale;
        playerIcon.localPosition = new Vector3(offset.x, offset.z, 0);
    }
}
