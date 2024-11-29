using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitStats : MonoBehaviour
{
    public int maxHealth; // 최대 체력
    public int attackDamage; // 공격력
    public float attackCooldown = 1.0f; // 공격 쿨타임
    public float attackRange = 1.5f; // 공격 범위

    [HideInInspector] public int currentHealth; // 현재 체력

    void Start()
    {
        currentHealth = maxHealth; // 초기 체력을 최대 체력으로 설정
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} 체력: {currentHealth}");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
