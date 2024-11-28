using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject[] SpawnUnit;


    public GameObject MonsterunitPrefab; // 생성할 적 유닛

    public Transform PlayerspawnPoint; // 플레이어 생성 위치
    public Transform MonsterspawnPoint; // 몬스터 생성 위치

    public float spawnInterval = 5000f; // 유닛 생성 간격
    public float spawnTimer; //유닛 생성 딜레이

    void Start()
    {

    }

    // 유닛 생성 스폰함수
    public void FarmerSpawn()
    {
        Instantiate(SpawnUnit[0], PlayerspawnPoint.position, Quaternion.identity); // 농부 생성
    }
    public void SwordSpawn()
    {
        Instantiate(SpawnUnit[1], PlayerspawnPoint.position, Quaternion.identity); // 전사 생성
    }
    public void HunterSpawn()
    {
        Instantiate(SpawnUnit[2], PlayerspawnPoint.position, Quaternion.identity); // 궁수 생성
    }

    void spawnMonster()
    {
        Instantiate(MonsterunitPrefab, MonsterspawnPoint.position, Quaternion.identity); // 몬스터 생성유닛
    }
}
