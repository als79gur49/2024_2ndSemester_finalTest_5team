using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGold : MonoBehaviour
{
    [SerializeField]
    private Image goidImage; //골드 이미지 -> ex)일정 수치 이상이면 이미지를 바꾸는 등의 활용
    [SerializeField]
    private TextMeshProUGUI goldText; //골드 숫자

    public void UpdateGoldHUD(int prev, int curr)
    {
        goldText.text = curr + "G";
    }
    /* //UnityEvent이용해서 Gold관리하는 곳에서 골드변할 때마다 Event 실행시키기 아래는 Gold관리하는 곳의 예시 코드, 인스펙터 창에 붙히면 됨.
    using UnityEngine;
using UnityEngine.Events;
public class TestUpdateGoldHUD : MonoBehaviour
{
    public UnityEvent<int, int> OnGoldChanged;

    public int gold = 0;

    public void AddGold()
    {
        int prev = gold;
        gold += 3;

        OnGoldChanged?.Invoke(prev, gold);
    }
}

    */
}
