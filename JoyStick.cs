using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour
{
    private PlayerMove pm;
    private Transform btn;
    private bool isPress = false;
    private float width = 91.0f;
    private float height = 91.0f;
    private float maxDistance = 43.0f;

    void Start()
    {
        pm = GameObject.FindGameObjectWithTag(Tags.player).transform.GetComponent<PlayerMove>();
        btn = transform.Find("Btn");
    }

    void Update()
    {
        if (isPress)
        {
            Vector2 touchPosition = UICamera.lastEventPosition;
            touchPosition -= new Vector2(width / 2, height / 2);
            float distance = Vector2.Distance(Vector2.zero, touchPosition);
            if (distance > maxDistance)
            {
                touchPosition = touchPosition.normalized * maxDistance;
            }
            btn.localPosition = touchPosition;

            float h = touchPosition.x / maxDistance;
            float v = touchPosition.y / maxDistance;
            if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
            {
                pm.isCanWalk = true;
                pm.targetDir = new Vector3(h, 0, v);
            }
        }
        else
        {
            pm.isCanWalk = false;
        }
    }

    void OnPress(bool isPress)
    {
        this.isPress = isPress;
        if (isPress == false)
        {
            btn.localPosition = Vector3.zero;
        }
    }
}
