using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventTrigger : MonoBehaviour
{
    [Header("플레이어 충돌 정보")]
    [Space(10f)]

    [Tooltip("다른 스크립트 주소에서 받아오기에 안 넣어도됨.")]
    private Rigidbody2D pRigidbody;//하트 프리팹 리지드바디 2D 입력.
    private SpriteRenderer pRenderer;

    [SerializeField]
    private LanaPlayer playerMove2d;//플레이어 스크립트 
    [SerializeField]
    private GameObject StarGazer; // 운석충돌.
    public GameObject StarGaze;

    public float timer = 0f;
    public float StarGazeTextTime = 2.0f;
    private bool Emergency = false;
    public bool onHit = false;//플레이어가 맞았을때,

    //점수창 저장 UI
    public UIScore ScoreUI;

    void Start()
    {
        pRigidbody = GetComponent<Rigidbody2D>();
        pRenderer = GetComponent<SpriteRenderer>();//스프라이트 렌더링.
        playerMove2d = GetComponent<LanaPlayer>();//시작시 플레이어 스크립트의 컴포넌트 참조.
    }

    [Tooltip("코루틴 Thread 함수. hit처리 될때, 액션 이벤트 정보 받아오기.")]

    public void Hit(int damage, Vector3 hitPos)
    {
        StartCoroutine(hitAction(hitPos));
    }

    [Tooltip("플레이어 맞는 액션처리.")]
    IEnumerator hitAction(Vector3 hitPos)
    {
        onHit = true;
        playerMove2d.enabled = false;//플레이어가 맞을때 받는 정보 false]

        pRenderer.color = new Color(1, 1, 1, 0.5f);

        Vector3 back_dir = Vector3.Normalize(gameObject.transform.position - hitPos);
        pRigidbody.AddForce(back_dir * 5f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.2f); //맞고 난후 

        playerMove2d.enabled = true;

        yield return new WaitForSeconds(0.8f);

        pRenderer.color = Color.white; //맞을때, 발생하는 색깔.
        onHit = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("NPC2"))//Npc랑 충돌할 경우.
        {
            ScoreUI.ScoreList2();//점수창
        }
        if (col.gameObject.CompareTag("NPC3"))//Npc랑 충돌할 경우.
        {
            ScoreUI.ScoreList3();//점수창
        }
        if (col.gameObject.CompareTag("NPC4"))//Npc랑 충돌할 경우.
        {
            ScoreUI.ScoreList4();//점수창
        }
        if (col.gameObject.CompareTag("ArrowHolder"))//유성우 
        {
   
              StarGazer.SetActive(true);
              StarGaze.SetActive(true);
              Emergency = true;
        
        }

    }
    private void Update()
    {  
        //일반적으로 텍스트가 나오다가 사라지는 코드.
        if (Emergency)
        {
            timer += Time.deltaTime;
            if (timer >= StarGazeTextTime)
            {
                StarGaze.SetActive(false);
                Emergency = false;
                timer = 0f;
            }
        }
    }
  
    public void ReStart()
    {
        SceneManager.LoadScene("2DMainSnowProtocol");
    }   //씬들

}