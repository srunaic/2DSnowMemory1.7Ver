using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour //,IPointerDownHandler
{
    [Header("타이핑 텍스트 자료구조 큐에 저장.")]
    public Text dialogueText;
    public GameObject nextText;
    public CanvasGroup dialoguegroup;
    public Queue<string> sentences;//저장

    //public Queue<int> door; //저장

    private string currentSentence;

    public float typingSpeed = 1f;//타이핑 속도.
    public bool istyping; //내가 대화 상태인가?


    [Tooltip("타이핑 UI 애니메이션.")]
    [SerializeField]

    private GameObject ObjUI;
    //public Animator anim;//애니메이션 
 
    public static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>(); //sentences초기화 Queue에 저장 되어있는지?
       //anim = GetComponent<Animator>();
    }

    //OnDialogue 라는 메서드를 만들어서 호출될때마다 큐에 대화를 넣고 대화창에 나오게 해준다.
    //OnDialogue메서드는 매개변수로 String 배열을 가진다.

    [Tooltip("여기서 타이핑이 최종 실행됨.")]
    public void OnDialogue(string[] lines)
    {
        //anim.SetTrigger("UIAnime");//애니메이션 직접 컨트롤.

        sentences.Clear();
        //sentences.Clear(); 메서드로 혹시 큐에 있을 데이터를 비워준다.
        //foreach문을 이용해서 전달 받은 인자들을 큐에 차례로 넣어준다.

        foreach (string line in lines) //string line은  지역변수 매게변수를 이 변수로 선언한거임.
        {
            sentences.Enqueue(line);//string 문장을 Queue에 넣기.
        }
        dialoguegroup.alpha = 1;
        dialoguegroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();//큐빼기 초기화.
            //코루틴.
            istyping = true;
            nextText.SetActive(false);//꺼짐.
            StartCoroutine(Typing(currentSentence));
        }

        else
        {

            dialoguegroup.alpha = 0;
            dialoguegroup.blocksRaycasts = false;
        }
    }

    void Update()
    {
        // dialoueText == currentSentence 대사 한줄 끝.
        if (dialogueText.text.Equals(currentSentence))
        {
            nextText.SetActive(true);
            istyping = false;
        }

    }

    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    /*public void OnPointerDown(PointerEventData eventData)
    {
        if (!istyping)
        {
             NextSentence();
        }
    }*///마우스 이벤트 처리

}
