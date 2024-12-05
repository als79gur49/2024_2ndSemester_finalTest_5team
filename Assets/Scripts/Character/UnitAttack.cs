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
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        if (!isAttack)
    //        {
    //            isAttack = true;
    //            SoundManager.Instance.PlaySound(SoundManager.Sfx.HunterSound);
    //            if (attackCoroutine != null)
    //            {
    //                StopCoroutine(attackCoroutine); // 기존의 공격 코루틴이 있다면 중지
    //            }
    //            attackCoroutine = StartCoroutine(AttackCoroutine(collision));
    //        }
    //    }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // if (collision.CompareTag("Enemy"))
       // {
       //     isAttack = false;
       //     if (attackCoroutine != null)
       //     {
       //         StopCoroutine(attackCoroutine); // 충돌이 끝났으므로 코루틴 중지
       //         attackCoroutine = null;
       //     }
       // }
    }
    private IEnumerator AttackCoroutine(Collider2D collision)
    {
        //    UnitStats enemyStats = collision.GetComponent<UnitStats>();
        //    while (true) // 충돌이 지속되는 동안 반복
        //    {
        //        enemyStats.TakeDamage(stats.attackDamage); // 공격 실행
        //        yield return new WaitForSeconds(stats.attackCooldown); // 쿨타임 기다리기
        //    }
        yield return null;
    }
}
