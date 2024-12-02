using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글톤 패턴
    public GameObject stageClearPanel;  // 스테이지 클리어 패널
    public GameObject stageDefeatPanel; // 스테이지 실패 패널

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowStageClearPanel()
    {
        if (stageClearPanel != null)
        {
            stageClearPanel.SetActive(true);
        }
    }
    public void ShowstageDefeatPanel()
    {
        if (stageDefeatPanel != null)
        {
            stageDefeatPanel.SetActive(true);
        }
    }
}
