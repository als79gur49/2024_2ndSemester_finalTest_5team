using UnityEngine.Events;
using UnityEngine;

public abstract class AbstractBlockerEvent : MonoBehaviour // ###문제 해결 완료### 더이상 사용하지 않는 스크립트
{                                                   //모든 내용을 UIBlocker => Open, Close버튼 이벤트 구독하게 전부 옮김.
                                                    //OnDisable은 비활성화 된 이후 바로 호출 but Invoke는 다음 프레임에 호출
                                                    // 그렇기에 Invoke를 통해 호출되는 코드들은 무조건 완전히 비활성화 된 이후 호출이기에
                                                    // 문제가 생길 수도 있기에, 방법 바꿈
    public UnityEvent<GameObject> UIOnEnableEvent;
    public UnityEvent<GameObject> UIOnDisableEvent;
    

    private void OnEnable() //이곳에서 this.gameObject를 보내도 인스펙터에서 직렬화된 필드가 우선순위가 더욱 높은 것 같음.
    {                       //확인해보니 인스펙터 창에서 매개변수를 설정할 때 두 가지라 나누어짐.
        //UIBlocker.OpenUI와 UIBlocker.OpenUI(GameObejct)로 나누어짐. 각각 초기화된 매개변수를 자동으로 사용, 수동 대입
        //UIOnEnableEvent?.Invoke(this.gameObject);
    }

    private void OnDisable()
    {
        Debug.Log("First");
       // UIOnDisableEvent?.Invoke(this.gameObject);
        Debug.Log("Second");
    }
}
