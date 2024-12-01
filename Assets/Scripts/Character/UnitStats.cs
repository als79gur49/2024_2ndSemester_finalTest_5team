using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    Unit,
    Enemy
}
[System.Serializable]
public class UnitStats : MonoBehaviour
{
    public UnitType unitType; // 유닛 타입
    public int maxHealth; // 최대 체력
    public int attackDamage; // 공격력
    public float attackCooldown = 1.0f; // 공격 쿨타임
    public float attackRange = 1.5f; // 공격 범위

    public int goldCost; // 유닛 별 가격
    public int goldReward; // 적 유닛 처치 시 지급할 골드
    private GoldSystem goldSystem;
    

    [HideInInspector] public int currentHealth; // 현재 체력

    public string unitName; //유닛 이름
    public Sprite unitImage; // Button에 띄어둘 유닛 이미지
    public float unitCooldown; // 유닛 재소환 시간

    void Start()
    {
        currentHealth = maxHealth; // 초기 체력을 최대 체력으로 설정
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} 체력: {currentHealth}");
        if(currentHealth <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        if(unitType == UnitType.Enemy)
        {
            // 적 유닛 사망 시 골드 지급
            goldSystem.AddGold(goldReward);
        }
        Destroy(gameObject);
    }
}
