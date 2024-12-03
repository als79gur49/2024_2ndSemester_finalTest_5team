using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // ½Ì±ÛÅæ ÆÐÅÏ

    public UnityEvent OnWinEvent; //½Â¸® ÀÌº¥Æ®
    public UnityEvent OnDefeatEvent; //ÆÐ¹è ÀÌº¥Æ®
    // StageManager¿¡¼­ ½Â¸®, ½ÇÆÐ UI ¶ç¿ì´Â ÀÌº¥Æ® ¿¬°áµÊ.

    private void Awake()
    {
        // ½Ì±ÛÅæ ¼³Á¤
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
