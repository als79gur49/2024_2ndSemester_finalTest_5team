using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도
    private Transform target; // 공격할 적
    private bool isAttack = false;

    private UnitStats stats; // 유닛 스탯
    private float lastAttackTime; // 마지막 공격시간
    private Coroutine attackCoroutine;

    void Start()
    {
        stats = GetComponent<UnitStats>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (!isAttack)
        {
            Move();
        }
    }

    // 플레이어 유닛 이동
    public void Move()
    {
        // 공격할 상대가 없으면 앞으로 이동
        if (target == null)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }

    //충돌 하고 있을 때
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(AttackCoroutine(collision));
            }
        }
    }

    // 충돌이 벗어날 때
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttack = false;
    }

    private IEnumerator AttackCoroutine(Collider2D collision)
    {
        UnitStats enemyStats = collision.GetComponent<UnitStats>();
        isAttack = true;
        while (true) // 충돌이 지속되는 동안 반복
        {
            enemyStats.TakeDamage(stats.attackDamage); // 공격 실행

            yield return new WaitForSeconds(stats.attackCooldown); // 쿨타임 기다리기
        }
    }
}
