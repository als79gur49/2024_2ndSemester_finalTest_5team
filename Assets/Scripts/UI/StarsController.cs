using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> stars; // 별의 위치 1, 2, 3일 경우 3, 1, 2순으로 가장 먼저 활성화 될 별부터 list에 넣기

    public int AchievedStars {  get; set; }

    private void Start()
    {
        int activedStars = 0;

        foreach(GameObject star in stars)
        {
            if(star.TryGetComponent<StarInfo>(out StarInfo starComponent))
            {
                if(activedStars < AchievedStars)
                {
                    starComponent.ActiveMain();
                    starComponent.ActiveBackground();

                    activedStars++;
                }
                else
                {
                    starComponent.DeactiveMain();
                    starComponent.ActiveBackground();
                }
            }
            else
            {
                continue;
            }
        }
    }

}
