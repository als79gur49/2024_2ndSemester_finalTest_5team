using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SoundSlider : MonoBehaviour
{
    //BGM, Effect Slider의 경우 Slider컴포넌트의 On Value Changed컴포넌트에 넣어서
    //씬 전환된 싱글턴 객체 인식 x => null, miss일 경우 자동으로 찾아주기
    private Slider slider;
    [SerializeField]
    private UnityAction<float> OccurEvent;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        
        slider.onValueChanged.AddListener(SoundManager.Instance.ToggleBGMSound);
    }

    private void Start()
    {
           
    }
}
