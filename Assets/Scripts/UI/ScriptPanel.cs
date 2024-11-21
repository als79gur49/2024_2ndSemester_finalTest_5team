using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPanel : MonoBehaviour
{
    [SerializeField]
    private int stageLevel; //스테이지 레벨 ex) 1, 2, 3, 4, 5

    [SerializeField]
    private StarsController starController;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private SceneLoader startButtonSceneLoader;

    private void Awake()
    {
        StageInfo currentStageInfo = DataManager.Instance.PlayerData.stageInfos[stageLevel];
        
        starController.AchievedStars = currentStageInfo.achievedStars;
        Debug.Log("ScriptPanel Awake Achieved");
        startButtonSceneLoader.SceneToLoad = currentStageInfo.stageName;
        text.text = currentStageInfo.stageName + "\n" + currentStageInfo.storyDetails;
    }
}
