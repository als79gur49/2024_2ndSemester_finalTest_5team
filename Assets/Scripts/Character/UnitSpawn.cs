using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawn : MonoBehaviour
{
    public GameObject unitPrefab; // 생성할 유닛 프리팹
    public Transform spawnPoint; // 생성 위치

    public float spawnInterval = 3f; // 유닛 생성 간격
    public float spawnTimer; //유닛 생성 딜레이

    // Update is called once per frame
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
        Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
    }
}
