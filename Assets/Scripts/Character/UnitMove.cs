using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도
    private Transform target; // 공격할 적
    private bool isAttack = false;



    void Start()
    {

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
    // 충돌 유지
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            isAttack = true;
        }
        
    }

    // 충돌이 벗어날 때
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isAttack = false;
        }
    }
}
