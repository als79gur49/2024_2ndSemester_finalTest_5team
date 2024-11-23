using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    private Slider BGMSlider;
    [SerializeField]
    private Slider effectSlider;

    private void Awake()
    {
        //슬라이더 함수 연결
        BGMSlider.onValueChanged.AddListener(SoundManager.Instance.ToggleBGMSound);
        effectSlider.onValueChanged.AddListener(SoundManager.Instance.ToggleEffectSound);

        //슬라이더 값을 저장된 값으로 초기화
        BGMSlider.value = SoundManager.Instance.BGMPlayer.GetComponent<AudioSource>().volume;
        effectSlider.value = SoundManager.Instance.EffectPlayer.GetComponent<AudioSource>().volume;
    }
}
