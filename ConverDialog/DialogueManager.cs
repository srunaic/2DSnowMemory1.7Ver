using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour //,IPointerDownHandler
{
    [Header("Ÿ���� �ؽ�Ʈ �ڷᱸ�� ť�� ����.")]
    public Text dialogueText;
    public GameObject nextText;
    public CanvasGroup dialoguegroup;
    public Queue<string> sentences;//����

    //public Queue<int> door; //����

    private string currentSentence;

    public float typingSpeed = 1f;//Ÿ���� �ӵ�.
    public bool istyping; //���� ��ȭ �����ΰ�?


    [Tooltip("Ÿ���� UI �ִϸ��̼�.")]
    [SerializeField]

    private GameObject ObjUI;
    //public Animator anim;//�ִϸ��̼� 
 
    public static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>(); //sentences�ʱ�ȭ Queue�� ���� �Ǿ��ִ���?
       //anim = GetComponent<Animator>();
    }

    //OnDialogue ��� �޼��带 ���� ȣ��ɶ����� ť�� ��ȭ�� �ְ� ��ȭâ�� ������ ���ش�.
    //OnDialogue�޼���� �Ű������� String �迭�� ������.

    [Tooltip("���⼭ Ÿ������ ���� �����.")]
    public void OnDialogue(string[] lines)
    {
        //anim.SetTrigger("UIAnime");//�ִϸ��̼� ���� ��Ʈ��.

        sentences.Clear();
        //sentences.Clear(); �޼���� Ȥ�� ť�� ���� �����͸� ����ش�.
        //foreach���� �̿��ؼ� ���� ���� ���ڵ��� ť�� ���ʷ� �־��ش�.

        foreach (string line in lines) //string line��  �������� �ŰԺ����� �� ������ �����Ѱ���.
        {
            sentences.Enqueue(line);//string ������ Queue�� �ֱ�.
        }
        dialoguegroup.alpha = 1;
        dialoguegroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();//ť���� �ʱ�ȭ.
            //�ڷ�ƾ.
            istyping = true;
            nextText.SetActive(false);//����.
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
        // dialoueText == currentSentence ��� ���� ��.
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
    }*///���콺 �̺�Ʈ ó��

}
