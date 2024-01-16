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
        if (Instance == null) //인스턴스 값 null
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        contactNpc = FindObjectOfType<ContactNpcMessage>();//얘도 참조하고 있음으로 받아옴.
        player = FindObjectOfType<LanaPlayer>();//이 플레이어를 시작할때 맨먼저 들고오겠다.
    }

    [Header("접촉NPC")]
    [Space(10f)]
    public ContactNpcMessage ContactNpc;

    [Tooltip("플레이어 무한맵 이동 관련 로직")]
    public LanaPlayer player;

    [Tooltip("UI 표시창")]
    public GameObject Npc2Talk;
    public GameObject Npc3Talk;
    public MessagePlayer msgPlayer;
    public GameObject talkPanel; //UI Panel말하는 패널.
    public TalkManager talkManager;//대화창.
    public KeyItemOption KeyItem;//키 아이템 습득시 발생.

    public GameObject ScoreImg;

    public Text talkText; //대화할 내용
    public int talkIndex = 0;
    public int talkIndex1 = 0;
    public GameObject scanObject; //Npc 오브젝트.


    public GameObject HiddenBlock;//숨겨진 오브젝트 특정 조건 만족시 발생.

    ///조건식 숨겨진 장애물들 애니메이션 컴포넌트 관리 <summary>

    [Tooltip("월드 상호작용 애니메이터 NPC 포함.")]

    public Animator CharryWinPose;//열쇠를 찾아줬을때, 발생할 애니메이션.

    public Animator block1;//숨겨진 오브젝트 조건 식 애니메이션 발생.
    public Animator block2;
    public Animator blcok3;
    /// </summary>
    /// 
    public Animator planetariumBlock;// 제 3월드에 숨겨진 비경 블락

    public bool isAction = false; //대화 행동 유무

    public void Action(GameObject scanObj)//LanaPlayer 스크립트 연동 개체.To TalkManager
    {
        if (!isAction) //참조변수 대화도중 이 아니고 레이어 마스크에 npc가 들어오면,
        {
            isAction = true;
            scanObject = scanObj;

            Objdata objData = scanObject.GetComponent<Objdata>();//오브젝트 데이터 자료구조

            Talk(objData.id, objData.isNpc);


            if (objData.id == 300 && isAction == true && KeyItem.isKey) //이 npc 데이터 id가 몇번일 때 작동하는지,
            {
                CharryWinPose.SetBool("GiveItem", true);
                ScoreImg.SetActive(true); //객체 점수 이미지 따로 지정.//여기에 대화창 뜨는 컴포넌트.               
                CharryWinPose.GetComponent<Animator>();
                HiddenBlock.SetActive(true);
                block1.GetComponent<Animator>();
                talkPanel.SetActive(true); // 패널 생성
            }

            else if (objData.id == 200) //200 ID를 가진 npc와 대화 상태일때,
            {
                  Npc3Talk.SetActive(true);
                  msgPlayer.dialogue = "뭔가 이상해";
                  msgPlayer.dialogue2 = "빨리 깨어나서 찾.아.야"; //msgPlayer 0.3초뒤 실행.
                  msgPlayer.showEmulator();
                  StartCoroutine(ActivatePortalAfterDelay(9f)); //연출효과 7초 뒤에 이 장면이 나옴.
            }

            Debug.Log("액션." + scanObj);
        }
  
    }
    public void NoneAction(GameObject scanObj) //NoneAction npc와 대화를 하는 도중이라면, 매개변수 scanObj
    {//공격 할 때 풀림.
        if (isAction == true)
        {
            isAction = false;
           //CharacterUI.SetActive(false);
            talkPanel.SetActive(false);
            Debug.Log("창 사라짐" + isAction);
        }

    }
    void Talk(int id, bool isNpc)// 매게변수 Npc1번 2번 port 퀘스트 
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null) // null 값 
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
        
        talkIndex++;//talkmanager의 대화내용"" , "" add 더 늘릴 수 있음.
    }

    private IEnumerator ActivatePortalAfterDelay(float delay)//씬 전환을 코루틴으로 관리.
    {
        yield return new WaitForSeconds(delay); //딜레이 시간이 지나면 다음 씬으로 대화 연출방식.
        SceneManager.LoadScene("LanaHouse");//추가기능.
    }

}