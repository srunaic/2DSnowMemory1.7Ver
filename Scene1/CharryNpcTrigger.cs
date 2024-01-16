using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharryNpcTrigger : MonoBehaviour
{
    [Header("열쇠의 정보를 캐릭터가 지니고 있다")]
    public static CharryNpcTrigger Instance; // 싱글톤 인스턴스.
    public KeyItemOption KeyItemTrig;
    public AudioManager audioManager;

    private void Awake()
    {
        if (Instance == null) //인스턴스 값 null
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }
        audioManager = FindObjectOfType<AudioManager>();
        KeyItemTrig = FindObjectOfType<KeyItemOption>();//얘도 참조하고 있음으로 받아옴.
    }

    [Tooltip("이 npc가 이 트기거 개체를 가지고 있고 key의 값을 들고와야지만 실행되는 함수.")]
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            audioManager.KeyItemQuick();
            KeyItemTrig.isKey = true;
        }
    }
}
