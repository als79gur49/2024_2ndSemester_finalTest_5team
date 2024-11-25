using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class StarsController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> stars; // 별의 위치 1, 2, 3일 경우 3, 1, 2순으로 가장 먼저 활성화 될 별부터 list에 넣기

    private bool isActivated;
    private int achievedStars;

    private void Awake()
    {
        Init(isActivated, achievedStars);
    }

    public void Init(bool isActivated, int achievedStars = 0)
    {
        List<StarInfo> targetStars = stars.Where(t => t.GetComponent<StarInfo>() != null). //StarInfo를 가지는 GameObject들 IEnumerable<GameObject>
                                            Select(t => t.GetComponent<StarInfo>()). // IEnumerable<GameObject> => IEnumerable<StarInfo>
                                            ToList(); // IEnumerable<StarInfo> => List<StarInfo>
        //별 출력 활성화
        if (isActivated)
        {
            int activatedStars = 0;

            //달성된 별 개수만큼만 활성화
            foreach (StarInfo star in targetStars)
            {
                if (activatedStars < achievedStars)
                {

                    star.ActiveMain();
                    star.ActiveMain();
                    activatedStars++;
                }
                else
                {
                    star.DeactiveMain();
                    star.ActiveBackground();
                }
            }
        }
        else
        {
            targetStars.ForEach(t => t.DeactiveMain());
            targetStars.ForEach(t => t.DeactiveBackground());
        }
    }
}
