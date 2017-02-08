using UnityEngine;
using System.Collections;

public class PlayerAward : MonoBehaviour
{

    public void GetAward(AwardType type)
    {
        if (type == AwardType.DualSword)
        {
            WeaponTime.instance.dualSwordTime += 10.0f;
        }
        else if (type == AwardType.Gun)
        {
            WeaponTime.instance.gunTime += 10.0f;
        }
    }
}
