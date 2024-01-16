using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ContactNpcMessage contactNpc;

    public Vector3 inputVec;

    private void Awake()
    {
        if (Instance == null) //�ν��Ͻ� �� null
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        contactNpc = FindObjectOfType<ContactNpcMessage>();//�굵 �����ϰ� �������� �޾ƿ�.
        player = FindObjectOfType<LanaPlayer>();//�� �÷��̾ �����Ҷ� �Ǹ��� �����ڴ�.
    }

    [Header("����NPC")]
    [Space(10f)]
    public ContactNpcMessage ContactNpc;

    [Tooltip("�÷��̾� ���Ѹ� �̵� ���� ����")]
    public LanaPlayer player;

    [Tooltip("UI ǥ��â")]
    public GameObject Npc2Talk;
    public GameObject Npc3Talk;
    public MessagePlayer msgPlayer;
    public GameObject talkPanel; //UI Panel���ϴ� �г�.
    public TalkManager talkManager;//��ȭâ.
    public KeyItemOption KeyItem;//Ű ������ ����� �߻�.

    public GameObject ScoreImg;

    public Text talkText; //��ȭ�� ����
    public int talkIndex = 0;
    public int talkIndex1 = 0;
    public GameObject scanObject; //Npc ������Ʈ.


    public GameObject HiddenBlock;//������ ������Ʈ Ư�� ���� ������ �߻�.

    ///���ǽ� ������ ��ֹ��� �ִϸ��̼� ������Ʈ ���� <summary>

    [Tooltip("���� ��ȣ�ۿ� �ִϸ����� NPC ����.")]

    public Animator CharryWinPose;//���踦 ã��������, �߻��� �ִϸ��̼�.

    public Animator block1;//������ ������Ʈ ���� �� �ִϸ��̼� �߻�.
    public Animator block2;
    public Animator blcok3;
    /// </summary>
    /// 
    public Animator planetariumBlock;// �� 3���忡 ������ ��� ���

    public bool isAction = false; //��ȭ �ൿ ����

    public void Action(GameObject scanObj)//LanaPlayer ��ũ��Ʈ ���� ��ü.To TalkManager
    {
        if (!isAction) //�������� ��ȭ���� �� �ƴϰ� ���̾� ����ũ�� npc�� ������,
        {
            isAction = true;
            scanObject = scanObj;

            Objdata objData = scanObject.GetComponent<Objdata>();//������Ʈ ������ �ڷᱸ��

            Talk(objData.id, objData.isNpc);


            if (objData.id == 300 && isAction == true && KeyItem.isKey) //�� npc ������ id�� ����� �� �۵��ϴ���,
            {
                CharryWinPose.SetBool("GiveItem", true);
                ScoreImg.SetActive(true); //��ü ���� �̹��� ���� ����.//���⿡ ��ȭâ �ߴ� ������Ʈ.               
                CharryWinPose.GetComponent<Animator>();
                HiddenBlock.SetActive(true);
                block1.GetComponent<Animator>();
                talkPanel.SetActive(true); // �г� ����
            }

            else if (objData.id == 200) //200 ID�� ���� npc�� ��ȭ �����϶�,
            {
                  Npc3Talk.SetActive(true);
                  msgPlayer.dialogue = "���� �̻���";
                  msgPlayer.dialogue2 = "���� ����� ã.��.��"; //msgPlayer 0.3�ʵ� ����.
                  msgPlayer.showEmulator();
                  StartCoroutine(ActivatePortalAfterDelay(9f)); //����ȿ�� 7�� �ڿ� �� ����� ����.
            }

            Debug.Log("�׼�." + scanObj);
        }
  
    }
    public void NoneAction(GameObject scanObj) //NoneAction npc�� ��ȭ�� �ϴ� �����̶��, �Ű����� scanObj
    {//���� �� �� Ǯ��.
        if (isAction == true)
        {
            isAction = false;
           //CharacterUI.SetActive(false);
            talkPanel.SetActive(false);
            Debug.Log("â �����" + isAction);
        }

    }
    void Talk(int id, bool isNpc)// �ŰԺ��� Npc1�� 2�� port ����Ʈ 
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null) // null �� 
        {
            isAction = false;
            return;
        }
        if (isNpc)
        {
            talkText.text = talkData;

        }
        else
        {
            talkText.text = talkData;
        }
        isAction = true;
        
        talkIndex++;//talkmanager�� ��ȭ����"" , "" add �� �ø� �� ����.
    }

    private IEnumerator ActivatePortalAfterDelay(float delay)//�� ��ȯ�� �ڷ�ƾ���� ����.
    {
        yield return new WaitForSeconds(delay); //������ �ð��� ������ ���� ������ ��ȭ ������.
        SceneManager.LoadScene("LanaHouse");//�߰����.
    }

}