using System.IO;
using UnityEngine;
using System.Text;
public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null) //Awake이전 호출 시, 초기화
            {
                instance = FindObjectOfType<DataManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("DataManager");
                    instance = obj.AddComponent<DataManager>();

                    DontDestroyOnLoad(obj);
                }
            }

            return instance;
        }
    }

    private PlayerData playerData;
    private string dataPath;

    public PlayerData PlayerData
    {
        get { return playerData; }
        set { playerData = value; }
    }

    private void Awake() //싱글턴 패턴
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);

            return;
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);//싱글턴

        dataPath = Path.Combine(Application.dataPath, "PlayerData.json");
        //최초 초기화
        LoadData();
    }

    public void LoadData()
    {
        if(File.Exists(dataPath))
        {   //FileStream과 달리 자동으로 Close()를 해주기에 편함
            string json = File.ReadAllText(dataPath); //파일 읽어오기

            playerData = new PlayerData();

            playerData = JsonUtility.FromJson<PlayerData>(json); //읽어온 파일을 객체에 맞게 변환
            //필요하면 데이터 유효성 검사하기. 최대클리어스테이지와 각 스테이지별 클리어 유무 및 별 획득 개수 등

            Debug.Log(JsonUtility.ToJson(playerData));
        }
        else
        {
            playerData = new PlayerData();
            Debug.Log($"{playerData}이 존재하지 않아 {JsonUtility.ToJson(playerData)}초기화 후 {dataPath}에 생성하였습니다.");
        }
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(playerData);
        //(기존 파일 삭제 후)새 파일 생성 후 데이터 저장 후 자동으로 Close()
        File.WriteAllText(dataPath, json);
        Debug.Log($"{json}내용이 {dataPath}에 저장되었습니다.");
    }
}
