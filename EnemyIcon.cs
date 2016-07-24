using UnityEngine;
using System.Collections;

public class EnemyIcon : MonoBehaviour
{
    private Transform icon;
    private float scale = 5.0f;

    void Start()
    {
        if (tag == Tags.monster)
        {
            icon = Minmap.instance.GetMonsterIcon().transform;
        }
        else if (tag == Tags.boss)
        {
            icon = Minmap.instance.GetBossIcon().transform;
        }
    }

    void Update()
    {
        Vector3 offset = transform.position;
        offset *= scale;
        icon.localPosition = new Vector3(offset.x, offset.z, 0);
    }

    void OnDestroy()
    {
        if (icon != null)
        {
            Destroy(icon.gameObject);
        }
    }
}
