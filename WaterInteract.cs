using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaterInteract : MonoBehaviour, Interactable
{
    [Header("���� �÷��̾��� ���� ���� �Ǵ� ����")]
    public bool waterDirect = true; //������ �ƴ��� �Ǻ�.

    //��ȣ�ۿ� �Ǵµ� �̸� ���� �����ؾ��� ��ü��.
    [SerializeField]
    private LanaPlayer player;
    [SerializeField]
    private ContactNpcMessage ContactWaterDialogue;
    public FaidInOut FadeInOut;
    public LivingEntity Entity;
    public PlayerStatus playerState;

    public Animator anim; // �÷��̾��� �ִϸ��̼� ��������.
    public bool isSwim = false;//�ִϸ��̼� ���� ������ �ƴ���,

    [Tooltip("Ÿ�̸� ����.")]
    private float WaterInTimer = 0f;//�帣�� Ÿ�̸� �ð�.
    public float InTime = 30f;//���� �����ð�
    public float TimeLimitallDead = 3f; //���ӿ��� ������ �ϳ� 30�ʰ� ���� �ں��� �߻��� ���.

    public Transform MainPlayerPortal;//��Ƽ�� �̵��� ��ġ.

    //UI����
    public Text timerText;

    public bool UseDirect
    {
        get { return waterDirect; } // ���̶��, �۵�.
    }
    //�������� �� ���Ͷ�.
    void Awake()
    {
        playerState = FindObjectOfType<PlayerStatus>();
        Entity = FindObjectOfType<LivingEntity>();
        FadeInOut = FindObjectOfType<FaidInOut>();
        ContactWaterDialogue = FindObjectOfType<ContactNpcMessage>();
        player = FindObjectOfType<LanaPlayer>();
        Entity.waterDamage = 0.1f; //�� ���� �������� 10 �÷��̾� hp bar���� ����
    }
 
    public void Interact(GameObject player)
    {
        SwimWater(player);
    }
    public void SwimWater(GameObject SwimPlayer) //�±׸� ���� �ʰ� �������̽��� �ִϸ����� ����.
    {
        player.Swim();//�÷��̾ ����� ���� �ִϸ��̼� ����.
        SurviveWaterUser();
    }

    [Tooltip("ContactWater�� ���� ���丮 ��ȭâ�� �����ϴ� �Լ��̴�.")]

    public void SurviveWaterUser()//���ӿ��� ��ƾ�ٸ�,
    {
        if (Input.GetKeyDown(KeyCode.Z)) //������Ʈ �ϼ���
        {
           ContactWaterDialogue.ContactWater();//���� ȥ�㸻 ��ȭâ �۵�.
        }

        //�浹�� ������ �߻��� ������ ������.
        WaterInTimer += Time.deltaTime;
        timerText.enabled = true;
        timerText.text = "�� ������ �ð� " + Mathf.RoundToInt(InTime - WaterInTimer).ToString(); // UI Text�� Ÿ�̸� �� ǥ��
        player.maxSpeed = 3f; //���ӿ� ������ ������ �ӵ� ����.
        player.moveForce = 10f;
        StartCoroutine(CheckSurvive()); //���ӿ��� �������� �޴� ���� 10�� �� �߻�.

        //false
        if (WaterInTimer >= InTime)//50�ʰ� ���� �Ŀ� �����̵�.
        {
            player.transform.position = MainPlayerPortal.position;//�� ��ġ�� ���ƿ´�.
            player.maxSpeed = 5f; //���ӿ� ������ ������ �ӵ� ����.
            player.moveForce = 50f;
            player.isSwim = false;
            player.anim.SetBool("isSwim", false);
            timerText.enabled = false;
            player.Hit = false;
            player.CancelInvoke("DealWaterDamage()");
            FadeInOut.Fade();
            //���� ȥ�㸻 3��° ��ȭâ �۵�.
        }

    }
    IEnumerator CheckSurvive() //�����ϰ� �ִ� ���� 10�� ������ �� �߻���.
    {   
        yield return new WaitForSeconds(2f);
        playerState.WaterSurviveDamage();

    }
    
 
}
