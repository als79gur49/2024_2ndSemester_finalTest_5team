using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterAttack : MonoBehaviour
{
    private UnitStats stats; // 유닛 스탯
    private float lastAttackTime = 0f; // 마지막 공격시간
    private Coroutine attackCoroutine;
    private bool isAttack = false; // 공격 여부
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<UnitStats>();
    }

    //충돌 여부
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isAttack) // 공격중이 아니라면
            {
                isAttack = true;
                if (attackCoroutine != null)
                {
                    StopCoroutine(attackCoroutine); // 기존의 공격 코루틴이 있다면 중지
                }
                attackCoroutine = StartCoroutine(AttackCoroutine(collision));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttack = false;
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine); // 충돌이 끝났으므로 코루틴 중지
                attackCoroutine = null;
            }
        }
    }
    private IEnumerator AttackCoroutine(Collider2D collision)
    {
        UnitStats playerStats = collision.GetComponent<UnitStats>();
        isAttack = true;
        while (isAttack) // 충돌이 지속되는 동안 반복  /// true -> isAttack
        {
            playerStats.TakeDamage(stats.attackDamage); // 공격 실행

            yield return new WaitForSeconds(stats.attackCooldown); // 쿨타임 기다리기
        }
    }
}
