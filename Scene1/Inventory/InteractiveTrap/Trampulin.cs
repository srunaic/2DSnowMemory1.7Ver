using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampulin : MonoBehaviour
{
    [Header("Ʈ���޸� �̺�Ʈ �߻�.")]
    private LanaPlayer Player;

    //�ִϸ����� ����
    private Animator anim;

    //���� �浹 ����
    Rigidbody2D rb;

    private bool isPump = false; //�÷��̾ ƨ��� �ִ���.
    private float superJump = 20.0f; //�ʱ�ȭ.
    private float JumpDelay = -1.5f;

    private void Awake()
    {
        Player = GetComponent<LanaPlayer>();
    
    }

    private void OnTriggerEnter2D(Collider2D Bounce)
    {
        //�÷��̾� �±� ����.
        if(Bounce.CompareTag("Player")) 
        {
            isPump = true;
            Debug.Log("Player�� Ʈ���޸��� ����.");
            rb = Bounce.GetComponent<Rigidbody2D>(); //�ε����� ����.
            anim = Bounce.GetComponent<Animator>(); //Ʈ���޸� �ִϸ��̼� �ۿ�.

            if (isPump && Bounce != null) //True�϶��� ����. Bounce�����尡 ������ �ȵǾ��ų�, null �̶��,
            {
                superJump = rb.velocity.y; //�� superjump��� ������ �ް�, ������ �ٵ� �Ӽ��� y�� ���� �ۿ��ϴ� ���ۿ��� �븳.

                if (superJump < 0) //���� ������ 0���� ������, True;
                {

                    rb.velocity = Vector2.up * superJump * JumpDelay; //���� �ö󰡶�
                  
                }
                else
                    superJump = 0;

            }
        }
        
    }



}
