using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventTrigger : MonoBehaviour
{
    [Header("�÷��̾� �浹 ����")]
    [Space(10f)]

    [Tooltip("�ٸ� ��ũ��Ʈ �ּҿ��� �޾ƿ��⿡ �� �־��.")]
    private Rigidbody2D pRigidbody;//��Ʈ ������ ������ٵ� 2D �Է�.
    private SpriteRenderer pRenderer;

    [SerializeField]
    private LanaPlayer playerMove2d;//�÷��̾� ��ũ��Ʈ 
    [SerializeField]
    private GameObject StarGazer; // ��浹.
    public GameObject StarGaze;

    public float timer = 0f;
    public float StarGazeTextTime = 2.0f;
    private bool Emergency = false;
    public bool onHit = false;//�÷��̾ �¾�����,

    //����â ���� UI
    public UIScore ScoreUI;

    void Start()
    {
        pRigidbody = GetComponent<Rigidbody2D>();
        pRenderer = GetComponent<SpriteRenderer>();//��������Ʈ ������.
        playerMove2d = GetComponent<LanaPlayer>();//���۽� �÷��̾� ��ũ��Ʈ�� ������Ʈ ����.
    }

    [Tooltip("�ڷ�ƾ Thread �Լ�. hitó�� �ɶ�, �׼� �̺�Ʈ ���� �޾ƿ���.")]

    public void Hit(int damage, Vector3 hitPos)
    {
        StartCoroutine(hitAction(hitPos));
    }

    [Tooltip("�÷��̾� �´� �׼�ó��.")]
    IEnumerator hitAction(Vector3 hitPos)
    {
        onHit = true;
        playerMove2d.enabled = false;//�÷��̾ ������ �޴� ���� false]

        pRenderer.color = new Color(1, 1, 1, 0.5f);

        Vector3 back_dir = Vector3.Normalize(gameObject.transform.position - hitPos);
        pRigidbody.AddForce(back_dir * 5f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.2f); //�°� ���� 

        playerMove2d.enabled = true;

        yield return new WaitForSeconds(0.8f);

        pRenderer.color = Color.white; //������, �߻��ϴ� ����.
        onHit = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("NPC2"))//Npc�� �浹�� ���.
        {
            ScoreUI.ScoreList2();//����â
        }
        if (col.gameObject.CompareTag("NPC3"))//Npc�� �浹�� ���.
        {
            ScoreUI.ScoreList3();//����â
        }
        if (col.gameObject.CompareTag("NPC4"))//Npc�� �浹�� ���.
        {
            ScoreUI.ScoreList4();//����â
        }
        if (col.gameObject.CompareTag("ArrowHolder"))//������ 
        {
   
              StarGazer.SetActive(true);
              StarGaze.SetActive(true);
              Emergency = true;
        
        }

    }
    private void Update()
    {  
        //�Ϲ������� �ؽ�Ʈ�� �����ٰ� ������� �ڵ�.
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
    }   //����

}