using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject PlayerunitPrefab; // 생성할 플레이어 유닛
    public GameObject MonsterunitPrefab; // 생성할 적 유닛
    public Transform PlayerspawnPoint; // 플레이어 생성 위치
    public Transform MonsterspawnPoint; // 몬스터 생성 위치

    public float spawnInterval = 3f; // 유닛 생성 간격
    public float spawnTimer; //유닛 생성 딜레이

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnUnit();
            spawnTimer = 0f;
        }
    }

    // 유닛 생성 스폰함수
    void spawnUnit()
    {
        Instantiate(PlayerunitPrefab, PlayerspawnPoint.position, Quaternion.identity); // 플레이어 생성유닛
        Instantiate(MonsterunitPrefab, MonsterspawnPoint.position, Quaternion.identity); // 몬스터 생성유닛
    }
}
