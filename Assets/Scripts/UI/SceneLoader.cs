using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //씬 이름을 통해서 로드
    [SerializeField]
    private string sceneToLoad;
    
    public void LoadSceneByName()
    {
        //TODO: 찾지 못했을 경우 로그 띄우기
        SceneManager.LoadScene(sceneToLoad);

        Debug.Log($"{sceneToLoad}를 로드한다");
    }
}
