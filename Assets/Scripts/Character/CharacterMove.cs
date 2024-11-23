using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 3f; // 캐릭터 이동속도

    private Transform target; // 공격할 적
    private float attackTimer; // 공격 딜레이

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 적이 없으면 앞으로 이동
        if( target == null )
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}
