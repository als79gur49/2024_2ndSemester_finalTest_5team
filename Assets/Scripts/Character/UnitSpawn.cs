using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject[] SpawnUnit; // 플레이어 유닛 생성
    public GameObject[] MonsterUnit; // 랜덤 생성 유닛

    public Transform PlayerspawnPoint; // 플레이어 생성 위치
    public Transform MonsterspawnPoint; // 몬스터 생성 위치

    public UnitStats[] units; // 유닛 정보 배열
    private GoldSystem goldSystem;

    public float spawnDelay = 5f; // 몬스터 생성 간격

    private float lastSpawnTime; // 마지막으로 몬스터를 생성한 시간

    void Start()
    {
        goldSystem = FindObjectOfType<GoldSystem>();
    }

    void Update()
    {
        // 시간이 일정 간격 이상 경과했다면 몬스터 생성
        if (Time.time >= lastSpawnTime + spawnDelay)
        {
            SpawnMonster(); // 몬스터 생성
            lastSpawnTime = Time.time; // 마지막 생성 시간을 현재 시간으로 업데이트
        }
    }
    public void SpawnMonster()
    {
        int randomIndex = Random.Range(0, MonsterUnit.Length);
        Instantiate(MonsterUnit[randomIndex], MonsterspawnPoint.position, Quaternion.identity); // 몬스터 생성유닛
    }
    public void SpawnFarmerUnit()
    {
        if(goldSystem != null && goldSystem.currentGold > 50)
        {
            goldSystem.SpendGold(50);
            Instantiate(SpawnUnit[0], PlayerspawnPoint.position, Quaternion.identity);
        }
    }
    public void SpawnSwordUnit()
    {
        if (goldSystem != null && goldSystem.currentGold > 80)
        {
            goldSystem.SpendGold(80);
            Instantiate(SpawnUnit[1], PlayerspawnPoint.position, Quaternion.identity);
        }
    }
    public void SpawnHunterUnit()
    {
        if (goldSystem != null && goldSystem.currentGold > 85)
        {
            goldSystem.SpendGold(85);
            Instantiate(SpawnUnit[2], PlayerspawnPoint.position, Quaternion.identity);
        }
    }
}
