using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampulin : MonoBehaviour
{
    [Header("트램펄린 이벤트 발생.")]
    private LanaPlayer Player;

    //애니메이터 적용
    private Animator anim;

    //물리 충돌 적용
    Rigidbody2D rb;

    private bool isPump = false; //플레이어가 튕기고 있는지.
    private float superJump = 20.0f; //초기화.
    private float JumpDelay = -1.5f;

    private void Awake()
    {
        Player = GetComponent<LanaPlayer>();
    
    }

    private void OnTriggerEnter2D(Collider2D Bounce)
    {
        //플레이어 태그 관리.
        if(Bounce.CompareTag("Player")) 
        {
            isPump = true;
            Debug.Log("Player가 트램펄린에 닿음.");
            rb = Bounce.GetComponent<Rigidbody2D>(); //부딪힐때 실행.
            anim = Bounce.GetComponent<Animator>(); //트램펄린 애니메이션 작용.

            if (isPump && Bounce != null) //True일때만 적용. Bounce리지드가 실행이 안되었거나, null 이라면,
            {
                superJump = rb.velocity.y; //이 superjump라는 변수를 받고, 리지드 바디 속성이 y축 위로 작용하는 반작용을 대립.

                if (superJump < 0) //점프 했을때 0보다 작을때, True;
                {

                    rb.velocity = Vector2.up * superJump * JumpDelay; //위로 올라가라
                  
                }
                else
                    superJump = 0;

            }
        }
        
    }



}
