using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    public UIButton normalAttack;
    public UIButton rangeAttack;
    public UIButton redAttack;
    private Animator animator;
    private bool isCanAttackB = false;

    void Start()
    {
        EventDelegate ed1 = new EventDelegate(this, "OnNormalAttack");
        normalAttack.onClick.Add(ed1);
        EventDelegate ed2 = new EventDelegate(this, "OnRangeAttack");
        rangeAttack.onClick.Add(ed2);
        EventDelegate ed3 = new EventDelegate(this, "OnRedAttack");
        redAttack.onClick.Add(ed3);

        redAttack.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void OnNormalAttack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && isCanAttackB)
        {
            animator.SetTrigger("AttackB");
        }
        else
        {
            animator.SetTrigger("AttackA");
        }
    }

    void OnRangeAttack()
    {
        animator.SetTrigger("AttackRange");
    }

    void OnRedAttack()
    {
        animator.SetTrigger("AttackGun");
    }

    void AttackB1()
    {
        isCanAttackB = true;
    }

    void AttackB2()
    {
        isCanAttackB = false;
    }

    public void TurnToGun()
    {
        normalAttack.gameObject.SetActive(false);
        rangeAttack.gameObject.SetActive(false);
        redAttack.gameObject.SetActive(true);
    }

    public void TurnToSword()
    {
        normalAttack.gameObject.SetActive(true);
        rangeAttack.gameObject.SetActive(true);
        redAttack.gameObject.SetActive(false);
    }
}
