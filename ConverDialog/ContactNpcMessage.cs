using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ContactNpcMessage : MonoBehaviour
{
    public GameManager manager;
    //대화창 구현 로직 객체참조.
    public DialogueManager dialogueNpc;

    public TextViewer TextView; //숨겨진 Npc용 채팅창.

    //기존에 실행될 텍스트 문장.
    public string[] sentences;
    public string[] sentences2;

    //물속 상황 연출씬
    public string[] sentences3;
    public string[] sentences4;

    //대화중인가?
    public bool isTalk = false;

    public void Awake()
    {
        //manager = transform.Find("경로1/경로2/").GetComponent<GameManager>(); //자식들 참조.
        //manager = FindObjectsOfType<GameManager>(); //배열로 되어있는 객체를 찾고 싶을때, 쓰는 경로 설정.
        manager = FindObjectOfType<GameManager>();
        TextView = FindObjectOfType<TextViewer>(); //텍스트 뷰 들고옴.
    }

    [Tooltip("이는 인터페이스가 아니라 일반 태그를 이용한 접촉 대화방식.")]
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
    [Tooltip("대화 HiddenNpc")]
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
        if (manager.isAction == false) //대화 상태x
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                manager.isAction = true;

                if (manager.isAction == true)
                {
                    manager.Npc2Talk.SetActive(true);
                    DialogueManager.instance.OnDialogue(sentences);//이 문장 실행 후 변경.
                    //string senetence = sentences[4].ToString();//5번째 줄 대화내용.
                }

            }

            else if (Input.GetKey(KeyCode.Q)) //한번 더 명시화 만약 대화창 탈출 버튼을 다른 키로 바꾼다면 이것도 같이 바꿔줘야함.
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
        if (manager.isAction == false) //대화 상태x
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                manager.isAction = true;

                if (manager.isAction == true)
                {
                    manager.Npc2Talk.SetActive(true);
                    DialogueManager.instance.OnDialogue(sentences2);//이 문장 실행 후 변경.
                    //string senetence = sentences[4].ToString();//5번째 줄 대화내용.
                }

            }

            else if (Input.GetKey(KeyCode.Q)) //한번 더 명시화 만약 대화창 탈출 버튼을 다른 키로 바꾼다면 이것도 같이 바꿔줘야함.
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
            TextView.StartTextView(); //텍스트 처음 시작 작동 함수.
            TextView.NextTyping(); //텍스트 시작 후 다음 일 처리 함수.
            TextView.SetTextList(TextView.dialogData); //DB Scriptable 매게변수용 함수.
        }
        else
        {
            isTalk = false;
        }

    }

    [Tooltip("인터페이스용 접촉방식 대화창 구현.")]
    public void ContactWater() //접촉시 대화창 한개씩 실행. typing courouine
    {
        TextView.StartTextView(); //텍스트 처음 시작 작동 함수.
        TextView.NextTyping(); //텍스트 시작 후 다음 일 처리 함수.
        TextView.SetTextList(TextView.dialogData); //DB Scriptable 매게변수용 함수.
    }

   
}
