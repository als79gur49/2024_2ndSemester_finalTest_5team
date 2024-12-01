using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private UnitStats stats; // 유닛 스탯
    private float lastAttackTime = 0f; // 마지막 공격시간
    private Coroutine attackCoroutine;
    private bool isAttack = false; // 공격 속도
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
        UnitStats playerStats = collision.GetComponent<UnitStats>();
        isAttack = true;
        while (true) // 충돌이 지속되는 동안 반복
        {
            playerStats.TakeDamage(stats.attackDamage); // 공격 실행

            yield return new WaitForSeconds(stats.attackCooldown); // 쿨타임 기다리기
        }
    }
}
