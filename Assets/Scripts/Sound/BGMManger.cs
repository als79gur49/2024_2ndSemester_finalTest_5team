using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManger : MonoBehaviour
{
    //브금 리스트의 Key와 씬의 name이 같은 경우 해당 name의 브금 출력
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // 씬 로드 이벤트에서 함수 제거
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {   //씬의 이름과 브금의 key이름이 같을 경우 브금 출력하게 설정
        SoundManager.Instance.PlayBGMAudio(scene.name);
        if (SoundManager.Instance.PlayBGMAudio(scene.name))
        {
            Debug.Log($"씬 로드완료: {scene.name}, 배경음악 출력");
        }
        else
        {
            Debug.Log($"씬 로드완료: {scene.name}, 배경음악을 찾을 수 없어 출력 불가능");
        }
    }
}
