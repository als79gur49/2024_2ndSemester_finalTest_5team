using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // 캐릭터 변수
    public float moveSpeed = 3f; // 캐릭터 이동속도
    public float attackRange = 1f; // 공격 범위
    public float attackCoolDown = 1f; // 공격 딜레이

    private Transform target; // 공격할 적
    private float attackTimer; // 공격 딜레이
    private bool isAttack = false; // 공격중인지 상태 체크

    // Start is called before the first frame update
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
        else
        {

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적 유닛을 찾음
        if (collision.CompareTag("Enemy"))
        {
            isAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isAttack = false;
        }
    }
}
