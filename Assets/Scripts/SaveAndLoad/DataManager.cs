using System.IO;
using UnityEngine;
using System.Text;

[RequireComponent(typeof(JsonSaveAndLoader))]
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


    private JsonSaveAndLoader saveAndLoader;
    private PlayerData playerData;

    public PlayerData PlayerData //TODO: 시간 되면 Wrapper클래스처럼 외부 노출 제어해보기
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
        
        saveAndLoader = new JsonSaveAndLoader(); //초기화, 기본 PlayerData.json
        //최초 초기화
        LoadData();
    }

    public void LoadData()
    {
        playerData = saveAndLoader.LoadData();
    }

    public void SaveData()
    {
        saveAndLoader.SaveData(playerData);
    }
}
