[System.Serializable]
public class PlayerData
{
    public int stageLevel; //클리어한 스테이지
    public Settings settings;

    public PlayerData()
    {
        stageLevel = 1;

        settings = new Settings();
        settings.masterVolume = 0;
        settings.bgmVolume = 0;
        settings.effectVolume = 0;
    }
}

[System.Serializable]
public class Settings
{    //value: -80 ~ 20
    public int masterVolume; //AudioMixer의 볼륨들
    public int bgmVolume; //모든 볼륨들은 반드시 여러 Volume 중 하나로 출력하기
    public int effectVolume;
}

