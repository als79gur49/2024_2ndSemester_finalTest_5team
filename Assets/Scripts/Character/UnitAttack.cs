using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    private UnitStats stats; // 유닛 스탯
    private float lastAttackTime; // 마지막 공격시간
    private Coroutine attackCoroutine;
    private bool isAttack = false; // 공격 여부

    void Start()
    {
        stats = GetComponent<UnitStats>();
    }
    //충돌 하고 있을 때
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isAttack = true;
            if (attackCoroutine == null)
            {
                
                attackCoroutine = StartCoroutine(AttackCoroutine(collision));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttack = false;
    }
    private IEnumerator AttackCoroutine(Collider2D collision)
    {
        UnitStats enemyStats = collision.GetComponent<UnitStats>();
        while (true) // 충돌이 지속되는 동안 반복
        {
            enemyStats.TakeDamage(stats.attackDamage); // 공격 실행

            yield return new WaitForSeconds(stats.attackCooldown); // 쿨타임 기다리기
        }
    }
}
