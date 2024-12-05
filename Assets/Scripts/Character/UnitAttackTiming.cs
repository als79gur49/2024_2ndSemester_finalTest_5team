using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitAttackTiming : MonoBehaviour
{
    [SerializeField]
    public string targetTag = "Enemy";

    private GameObject target;
    private List<GameObject> targetLists;
    private UnitStats stat;

    private void Awake()
    {
        stat = GetComponentInParent<UnitStats>();
        //stat = GetComponent<UnitStats>();
        targetLists = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( ! collision.CompareTag(targetTag)) //목표만 검색
        {
            return;
        }

        if( ! targetLists.Contains(collision.gameObject) )// 예비목표들을 리스트에 저장
        {
            targetLists.Add(collision.gameObject);
        }

        if (target == null) // 목표가 없으면 새로 지정
        {
            target = collision.gameObject;

            Debug.Log("NewTarget");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetLists.Contains(collision.gameObject))
        {
            targetLists.Remove(collision.gameObject);
        }
    }

    public void Attack()
    {
        if(target == null) //타겟이 비어있으면, 예비타겟에서 가져오기
        {
            target = targetLists.FirstOrDefault();
        }

        if(target == null)//그래도 없다면 리턴
        {
            return;
        }

        if(target.TryGetComponent<UnitStats>(out UnitStats targetStat))
        {
            targetStat.TakeDamage(stat.attackDamage);
        }
    }
}
