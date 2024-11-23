using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterMove : MonoBehaviour
{
    public float moveSpeed = 3f; // 몬스터 이동속도

    private Transform target; // 공격할 플레이어
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

    public void Move()
    {
        // 공격할 상대가 없으면 앞으로 이동
        if (target == null)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적 유닛을 찾음
        if (collision.CompareTag("Player"))
        {
            isAttack = true;
            Debug.Log("공격");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttack = false;
            Debug.Log("빠져나감");
        }
    }
}
