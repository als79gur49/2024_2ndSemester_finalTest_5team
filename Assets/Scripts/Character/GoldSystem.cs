using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldSystem : MonoBehaviour
{
    public int currentGold = 100; // 초기 골드 값
    public int GainGold = 10; // 초당 지급되는 골드
    private float timer = 0f; // 시간 추적

    public Text goldText; // UI 텍스트 표시
    public Button[] spendGoldButton; // UI 버튼 표시

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // 1초마다 골드 지급
        if(timer >= 1f)
        {
            AddGold(GainGold);
            timer = 0f; // 타이머 초기화
        }
    }

    // 골드를 추가하는 메서드
    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldText(); // UI 업데이트
    }
    // 골드 표시 텍스트 업데이트
    private void UpdateGoldText()
    {
        goldText.text = "Gold" + currentGold;
    }
    // 골드를 소비하는 메서드
    public void SpendGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldText(); // UI 업데이트
        }
    }
}
