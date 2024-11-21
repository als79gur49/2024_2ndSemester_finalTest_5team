using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Pair
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    //게임오브젝트인 Player를 통해서 소리를 출력하는 형태
    //bgm의 경우 일반적인 Play
    //Effect는 shot으로 주로 Play
    [SerializeField]
    private AudioMixer audioMixer; 
    [SerializeField] 
    private GameObject bgmPlayer;
    [SerializeField]
    private GameObject effectPlayer;

    #region 볼륨 수정하는 변수들 
    //TODO: 볼륨의 크기가 선형이 아니라 로그 스케일인 것 같음. 변환이 필요
    [SerializeField]
    [Range(-80, 20)] 
    private float currentMasterVolume;

    [SerializeField]
    [Range(-80, 20)]
    private float currentBGMVolume;

    [SerializeField]
    [Range(-80, 20)]
    private float currentEffectVolume;

    public float MasterVolume
    {
        get => currentMasterVolume;
        set
        {
            currentMasterVolume = Mathf.Clamp(value, -80, 20);
            audioMixer.SetFloat("MasterVolume", currentMasterVolume);
        }
    }
    public float BGMVolume
    {
        get => currentBGMVolume;
        set
        {
            currentBGMVolume = Mathf.Clamp(value, -80, 20);
            audioMixer.SetFloat("BGMVolume", currentBGMVolume);
        }
    }
    public float EffectVolume
    {
        get => currentEffectVolume;
        set
        {
            currentEffectVolume = Mathf.Clamp(value, -80, 20);
            audioMixer.SetFloat("EffectVolume", currentEffectVolume);
        }
    }
    #endregion

    [SerializeField] //Dictionary로 중복되지 않게 하려고 했는데 Dictionary는 Serialize가 되지 않아서 따로 class생성
    private List<Pair> bgmClips;
    [SerializeField]
    private List<Pair> effectClips;


    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null) //Awake이전 호출 시, 초기화
            {
                instance = FindObjectOfType<SoundManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("SoundManager");
                    instance = obj.AddComponent<SoundManager>();

                    DontDestroyOnLoad(obj);
                }
            }

            return instance;
        }
    }

    private void OnValidate() //인스펙터 창에서 값 수정 시 호출되는 함수
    {   //인스펙터에서 수정 시 값이 적용이 되지않아서 사용하는 함수
        MasterVolume = currentMasterVolume;
        BGMVolume = currentBGMVolume;
        EffectVolume = EffectVolume;
    }
    private void Awake() //싱글턴 패턴
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        MasterVolume = currentMasterVolume;
        BGMVolume = currentBGMVolume;
        EffectVolume = EffectVolume;
    }

    private bool _PlayBGMAudio(string clipName, out AudioClip audioClip,float rate = 0.0f)//클립, 시작 위치
    {      
        audioClip = GetClip(clipName, bgmClips);

        if (audioClip == null)
        {
            Debug.Log($"BGMSound에서 {clipName}을 찾을 수 없습니다.");

            return false;
        }

        if (rate > 1.0f)
        {
            Debug.Log($"BGMSound의 Rate{rate} > 1.0f가 커서 실행 불가능");

            return false;
        }

        bgmPlayer.GetComponent<AudioSource>().clip = audioClip;
        bgmPlayer.GetComponent<AudioSource>().time = rate * audioClip.length;
        bgmPlayer.GetComponent<AudioSource>().Play();

        return true;
    }

    public bool PlayBGMAudio(string clipName, float rate = 0.0f)
    {
        _PlayBGMAudio(clipName, out _, rate);

        return true;
    }

    public bool PlayBGMAudio(string clipName, out AudioClip audioClip, float rate = 0.0f)
    {
        _PlayBGMAudio(clipName, out audioClip, rate);

        return true;
    }


    private bool _PlayEffectAudio(string clipName, out AudioClip audioClip, float volume = 1f)//클립, 출력 크기
    {
        audioClip = GetClip(clipName, effectClips);

        if (audioClip == null)
        {
            Debug.Log($"EffectSound에서 {clipName}을 찾을 수 없습니다.");

            return false;
        }

        effectPlayer.GetComponent<AudioSource>().PlayOneShot(audioClip, volume);

        return true;
    }
    public bool PlayEffectAudio(string clipName, float volume = 1f)
    {
        _PlayEffectAudio(clipName, out _, volume);

        return true;
    }
    public bool PlayEffectAudio(string clipName, out AudioClip audioClip, float volume = 1f)
    {
        _PlayEffectAudio(clipName, out audioClip, volume);

        return true;
    }

    private AudioClip GetClip(string name, List<Pair> list) //내부 함수, string -> 알맞은 AudioClip반환
    {
        foreach (Pair pair in list)
        {
            if (pair.name == name)
            {
                return pair.clip;
            }
        }

        return null;
    }
    
    //외부에서 소리 On/Off기능, 0, 1
    /*public void ToggleMasterSound(float value)
    {                   // -80 ~ 0
        MasterVolume = -80 + (value * 80);
    }
    */
    public void ToggleBGMSound(float value)//소리의 OnOff는 AudioMixer 대신 AudioSource에서 수정
    {
        bgmPlayer.GetComponent<AudioSource>().volume = value;
    }
    public void ToggleEffectSound(float value)
    {
        effectPlayer.GetComponent<AudioSource>().volume = value;
    }
}
