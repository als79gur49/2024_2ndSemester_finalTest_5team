using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUnitMove : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도
    private Transform target; // 공격할 적
    private bool isAttack = false;

    private UnitStats stats; // 유닛 스탯
    private float lastAttackTime = 0f; // 마지막 공격시간

    void Start()
    {
        stats = GetComponent<UnitStats>();
    }
    // Update is called once per frame
    void Update()
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
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    //충돌 여부
    private void OnTriggerStay2D(Collider2D collision)
    {
        

        // Player 태그를 가진 오브젝트와 충돌하였을 때
        if (collision.CompareTag("Player"))
        {
            isAttack = true;

            if (Time.time > lastAttackTime + stats.attackCooldown)
            {
                UnitStats playerStats = collision.GetComponent<UnitStats>();
                if (playerStats != null)
                {
                    // 적에게 데미지를 입힘
                    playerStats.TakeDamage(stats.attackDamage);
                    Debug.Log($"{gameObject.name}이 {collision.gameObject.name}에게 {stats.attackDamage} 데미지를 입혔습니다.");
                    lastAttackTime = Time.time; // 공격 시간 갱신
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttack = false;
    }
}
