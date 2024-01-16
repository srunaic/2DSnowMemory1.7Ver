using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharryNpcTrigger : MonoBehaviour
{
    [Header("������ ������ ĳ���Ͱ� ���ϰ� �ִ�")]
    public static CharryNpcTrigger Instance; // �̱��� �ν��Ͻ�.
    public KeyItemOption KeyItemTrig;
    public AudioManager audioManager;

    private void Awake()
    {
        if (Instance == null) //�ν��Ͻ� �� null
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }
        audioManager = FindObjectOfType<AudioManager>();
        KeyItemTrig = FindObjectOfType<KeyItemOption>();//�굵 �����ϰ� �������� �޾ƿ�.
    }

    [Tooltip("�� npc�� �� Ʈ��� ��ü�� ������ �ְ� key�� ���� ���;����� ����Ǵ� �Լ�.")]
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            audioManager.KeyItemQuick();
            KeyItemTrig.isKey = true;
        }
    }
}
