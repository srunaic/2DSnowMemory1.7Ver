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
        if (!isTalk)//���ϴ� ������ �ƴ϶��,
        {
            timer += Time.deltaTime;
            if (timer >= 4f) //�÷��̾� �� �Ҷ� 5�ʰ� ������ ����.
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

    IEnumerator ShowAndHideMessages() //������ �޽��� �ؽ�Ʈ ���� �ڷ�ƾ.
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
            yield return new WaitForSeconds(0.2f); //�ؽ�Ʈ 1��°�� �ٷ� ���������� ������.
            Message2.text += dialogue2[i];
            yield return new WaitForSeconds(0.3f);
        }

            yield return new WaitForSeconds(0.3f); //5�ʸ� ��ٷȴٰ� ����.
            Message2.enabled = false;

    }
}
