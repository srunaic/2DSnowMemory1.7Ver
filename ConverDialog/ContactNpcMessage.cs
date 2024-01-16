using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ContactNpcMessage : MonoBehaviour
{
    public GameManager manager;
    //��ȭâ ���� ���� ��ü����.
    public DialogueManager dialogueNpc;

    public TextViewer TextView; //������ Npc�� ä��â.

    //������ ����� �ؽ�Ʈ ����.
    public string[] sentences;
    public string[] sentences2;

    //���� ��Ȳ �����
    public string[] sentences3;
    public string[] sentences4;

    //��ȭ���ΰ�?
    public bool isTalk = false;

    public void Awake()
    {
        //manager = transform.Find("���1/���2/").GetComponent<GameManager>(); //�ڽĵ� ����.
        //manager = FindObjectsOfType<GameManager>(); //�迭�� �Ǿ��ִ� ��ü�� ã�� ������, ���� ��� ����.
        manager = FindObjectOfType<GameManager>();
        TextView = FindObjectOfType<TextViewer>(); //�ؽ�Ʈ �� ����.
    }

    [Tooltip("�̴� �������̽��� �ƴ϶� �Ϲ� �±׸� �̿��� ���� ��ȭ���.")]
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ContactNpc"))
        {
            Contact();
        }
        else if (other.CompareTag("ContactNpc2"))
        {
            Contact2();
        }
    }
    [Tooltip("��ȭ HiddenNpc")]
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HiddenNpc"))
        {
        
              isTalk = true;
              ContactHiddenNpc();
            
        }
    }

    public void Contact()
    {
        if (manager.isAction == false) //��ȭ ����x
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                manager.isAction = true;

                if (manager.isAction == true)
                {
                    manager.Npc2Talk.SetActive(true);
                    DialogueManager.instance.OnDialogue(sentences);//�� ���� ���� �� ����.
                    //string senetence = sentences[4].ToString();//5��° �� ��ȭ����.
                }

            }

            else if (Input.GetKey(KeyCode.Q)) //�ѹ� �� ���ȭ ���� ��ȭâ Ż�� ��ư�� �ٸ� Ű�� �ٲ۴ٸ� �̰͵� ���� �ٲ������.
            {
                manager.Npc2Talk.SetActive(false);

            }
        }

        else if (dialogueNpc.istyping == false)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                dialogueNpc.NextSentence();
            }
        }


    }
    public void Contact2()
    {
        if (manager.isAction == false) //��ȭ ����x
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                manager.isAction = true;

                if (manager.isAction == true)
                {
                    manager.Npc2Talk.SetActive(true);
                    DialogueManager.instance.OnDialogue(sentences2);//�� ���� ���� �� ����.
                    //string senetence = sentences[4].ToString();//5��° �� ��ȭ����.
                }

            }

            else if (Input.GetKey(KeyCode.Q)) //�ѹ� �� ���ȭ ���� ��ȭâ Ż�� ��ư�� �ٸ� Ű�� �ٲ۴ٸ� �̰͵� ���� �ٲ������.
            {
                manager.Npc2Talk.SetActive(false);

            }
        }

        else if (dialogueNpc.istyping == false)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                dialogueNpc.NextSentence();
            }
        }


    }
    public void ContactHiddenNpc()
    {
        if (isTalk)
        {
            TextView.StartTextView(); //�ؽ�Ʈ ó�� ���� �۵� �Լ�.
            TextView.NextTyping(); //�ؽ�Ʈ ���� �� ���� �� ó�� �Լ�.
            TextView.SetTextList(TextView.dialogData); //DB Scriptable �ŰԺ����� �Լ�.
        }
        else
        {
            isTalk = false;
        }

    }

    [Tooltip("�������̽��� ���˹�� ��ȭâ ����.")]
    public void ContactWater() //���˽� ��ȭâ �Ѱ��� ����. typing courouine
    {
        TextView.StartTextView(); //�ؽ�Ʈ ó�� ���� �۵� �Լ�.
        TextView.NextTyping(); //�ؽ�Ʈ ���� �� ���� �� ó�� �Լ�.
        TextView.SetTextList(TextView.dialogData); //DB Scriptable �ŰԺ����� �Լ�.
    }

   
}
