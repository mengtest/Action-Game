using UnityEngine;
using System.Collections;

public enum WeaponType
{
    SingleSword,
    DualSword,
    Gun
}

public class WeaponTime : MonoBehaviour
{
    public static WeaponTime instance;
    public GameObject singleSword;
    public GameObject dualSword;
    public GameObject gun;
    public UIButton singleSwordBtn;
    public UIButton dualSwordBtn;
    public UIButton gunBtn;
    public UILabel dualSwordUI;
    public UILabel gunUI;
    public float dualSwordTime = 0;
    public float gunTime = 0;
    private Transform player;
    private WeaponType weaponType = WeaponType.SingleSword;

    void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    void Start()
    {
        EventDelegate ed1 = new EventDelegate(this, "OnSingleSwordBtnClick");
        singleSwordBtn.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "OnDualSwordBtnClick");
        dualSwordBtn.onClick.Add(ed2);
        EventDelegate ed3 = new EventDelegate(this, "OnGunBtnClick");
        gunBtn.onClick.Add(ed3);
    }

    void Update()
    {
        float time = Time.deltaTime;
        if (dualSwordTime > 0)
        {
            dualSwordTime -= time;
            if (dualSwordTime < 0)
            {
                dualSwordTime = 0;
            }
        }
        if (gunTime > 0)
        {
            gunTime -= time;
            if (gunTime < 0)
            {
                gunTime = 0;
            }
        }
        dualSwordUI.text = Mathf.Round(dualSwordTime).ToString();
        gunUI.text = Mathf.Round(gunTime).ToString();

        //使用时间到了
        if ((dualSwordTime <= 0 && weaponType == WeaponType.DualSword) || (gunTime <= 0 && weaponType == WeaponType.Gun))
        {
            TurnToSingleSword();
        }
    }

    void OnSingleSwordBtnClick()
    {
        TurnToSingleSword();
    }

    void OnDualSwordBtnClick()
    {
        if (dualSwordTime > 0)
        {
            TurnToDualSword();
        }
    }

    void OnGunBtnClick()
    {
        if (gunTime > 0)
        {
            TurnTogGun();
        }
    }

    void TurnToSingleSword()
    {
        player.GetComponent<PlayerAnimation>().TurnToSword();
        singleSword.SetActive(true);
        dualSword.SetActive(false);
        gun.SetActive(false);
        weaponType = WeaponType.SingleSword;
    }

    void TurnToDualSword()
    {
        player.GetComponent<PlayerAnimation>().TurnToSword();
        singleSword.SetActive(false);
        dualSword.SetActive(true);
        gun.SetActive(false);
        weaponType = WeaponType.DualSword;
    }

    void TurnTogGun()
    {
        player.GetComponent<PlayerAnimation>().TurnToGun();
        singleSword.SetActive(false);
        dualSword.SetActive(false);
        gun.SetActive(true);
        weaponType = WeaponType.Gun;
    }
}
