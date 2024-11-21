using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    private int atLeastStar = 3;//최소 별 개수 및 별 배경 개수
    public int AchievedStars { get; set; }
    //최대 별의 개수를 조절하기 위해 스크립트 이용
    [SerializeField]
    private GameObject starPrefab;
    private List<GameObject> stars;


    //ScriptPanel, StagePanel스크립트에서 Awake에서 AchievedStars를 초기화 하는데, Awake() 호출 순서 때문에
    //StarsController를 Start에서 실행시킴
    private void Start()
    {
        stars = new List<GameObject>();

        for (int i = 0; i < atLeastStar; i++) //별의 배경만 생성
        {
            stars.Add(Instantiate(starPrefab));
            stars[i].transform.SetParent(this.transform, false);
            stars[i].GetComponent<StarInfo>().DeactiveMain();
        }

        Debug.Log("StarsController Awake Achieved");
        for (int i = 0; i < AchievedStars; i++) //획득된 별만큼 별 생성
        {
            stars[i]?.GetComponent<StarInfo>().ActiveMain();
        }
    }

}
