using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUnitMove : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도
    private Transform target; // 공격할 적
    private bool isAttack = false;

    void Start()
    {
        
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isAttack = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isAttack = false;
    }
}
