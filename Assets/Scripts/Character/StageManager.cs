using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryPanel;
    [SerializeField]
    private GameObject defeatedPanel;

    private void Awake()
    {
        //GameManager.Instance.OnWinEvent.AddListener(OpenVictoryPanel);  //게임 매니저 클래스의 이벤트에 연결
        //GameManager.Instance.OnDefeatEvent.AddListener(OpenDefeatPanel);
    }
    private void Start()
    {
        GameManager.Instance.OnWinEvent.AddListener(OpenVictoryPanel);  //게임 매니저 클래스의 이벤트에 연결
        GameManager.Instance.OnDefeatEvent.AddListener(OpenDefeatPanel);
    }

    private void OpenUI(GameObject panel) //비활성화 된 UI 활성화
    {
        panel.SetActive(true);
    }

    public void OpenVictoryPanel()
    {
        OpenUI(victoryPanel);
    }
    public void OpenDefeatPanel()
    {
        OpenUI(defeatedPanel);
    }
}
