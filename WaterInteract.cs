using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaterInteract : MonoBehaviour, Interactable
{
    [Header("물속 플레이어의 상태 여부 판단 로직")]
    public bool waterDirect = true; //물인지 아닌지 판별.

    //상호작용 되는데 이를 위에 참조해야할 객체들.
    [SerializeField]
    private LanaPlayer player;
    [SerializeField]
    private ContactNpcMessage ContactWaterDialogue;
    public FaidInOut FadeInOut;
    public LivingEntity Entity;
    public PlayerStatus playerState;

    public Animator anim; // 플레이어의 애니메이션 동작정보.
    public bool isSwim = false;//애니메이션 동작 중인지 아닌지,

    [Tooltip("타이머 설정.")]
    private float WaterInTimer = 0f;//흐르는 타이머 시간.
    public float InTime = 30f;//물속 생존시간
    public float TimeLimitallDead = 3f; //물속에서 생존은 하나 30초가 지난 뒤부터 발생할 사건.

    public Transform MainPlayerPortal;//버티면 이동될 위치.

    //UI관리
    public Text timerText;

    public bool UseDirect
    {
        get { return waterDirect; } // 물이라면, 작동.
    }
    //귀찮으니 다 들고와라.
    void Awake()
    {
        playerState = FindObjectOfType<PlayerStatus>();
        Entity = FindObjectOfType<LivingEntity>();
        FadeInOut = FindObjectOfType<FaidInOut>();
        ContactWaterDialogue = FindObjectOfType<ContactNpcMessage>();
        player = FindObjectOfType<LanaPlayer>();
        Entity.waterDamage = 0.1f; //물 수압 데미지는 10 플레이어 hp bar에서 차감
    }
 
    public void Interact(GameObject player)
    {
        SwimWater(player);
    }
    public void SwimWater(GameObject SwimPlayer) //태그를 쓰지 않고 인터페이스로 애니메이터 관리.
    {
        player.Swim();//플레이어에 적용된 수영 애니메이션 관리.
        SurviveWaterUser();
    }

    [Tooltip("ContactWater는 유저 스토리 대화창을 관리하는 함수이다.")]

    public void SurviveWaterUser()//물속에서 버틴다면,
    {
        if (Input.GetKeyDown(KeyCode.Z)) //업데이트 하세요
        {
           ContactWaterDialogue.ContactWater();//라나의 혼잣말 대화창 작동.
        }

        //충돌을 했을때 발생할 데이터 정보들.
        WaterInTimer += Time.deltaTime;
        timerText.enabled = true;
        timerText.text = "물 빠지는 시간 " + Mathf.RoundToInt(InTime - WaterInTimer).ToString(); // UI Text에 타이머 값 표시
        player.maxSpeed = 3f; //물속에 있으니 움직임 속도 제한.
        player.moveForce = 10f;
        StartCoroutine(CheckSurvive()); //물속에서 데미지를 받는 판정 10초 뒤 발생.

        //false
        if (WaterInTimer >= InTime)//50초가 지난 후에 순간이동.
        {
            player.transform.position = MainPlayerPortal.position;//원 위치로 돌아온다.
            player.maxSpeed = 5f; //물속에 있으니 움직임 속도 제한.
            player.moveForce = 50f;
            player.isSwim = false;
            player.anim.SetBool("isSwim", false);
            timerText.enabled = false;
            player.Hit = false;
            player.CancelInvoke("DealWaterDamage()");
            FadeInOut.Fade();
            //라나의 혼잣말 3번째 대화창 작동.
        }

    }
    IEnumerator CheckSurvive() //생존하고 있는 동안 10초 딜레이 후 발생함.
    {   
        yield return new WaitForSeconds(2f);
        playerState.WaterSurviveDamage();

    }
    
 
}
