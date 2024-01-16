using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePlayer : MonoBehaviour
{
    public Text Message;
    public Text Message2;

    public string dialogue;
    public string dialogue2;
  
    private float timer = 0.0f;

    private bool isTalk = false;
    
    void Update()
    {
        if (!isTalk)//말하는 도중이 아니라면,
        {
            timer += Time.deltaTime;
            if (timer >= 4f) //플레이어 말 할때 5초가 지나면 꺼짐.
            {
                Message.enabled = false;
            }
        }
        else
        {
            timer = 0.0f;
        }
    }

    public void showEmulator()
    {
        StartCoroutine(ShowAndHideMessages());
    }

    IEnumerator ShowAndHideMessages() //보여질 메시지 텍스트 관리 코루틴.
    {
        Message.text = null;
        Message2.text = null;

        for (int i = 0; i < dialogue.Length; i++)
        {
            Message.text += dialogue[i];
            yield return new WaitForSeconds(0.3f);
        }

        for (int i = 0; i < dialogue2.Length; i++)
        {
            yield return new WaitForSeconds(0.2f); //텍스트 1번째가 바로 끝나버리기 때문에.
            Message2.text += dialogue2[i];
            yield return new WaitForSeconds(0.3f);
        }

            yield return new WaitForSeconds(0.3f); //5초를 기다렸다가 제거.
            Message2.enabled = false;

    }
}
