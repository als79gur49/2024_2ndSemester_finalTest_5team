using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ButtonClickLimit : MonoBehaviour
{
    //Button 이벤트에 연결 및 매개변수 전달
    [SerializeField]
    private Button button;
    
    public void RestrictButtonClick2(float time)
    {
        StartCoroutine(Restrict(time));
    }
    private IEnumerator Restrict(float time)
    {
        button.interactable = false;

        yield return new WaitForSeconds(time);

        button.interactable = true;
    }
}
