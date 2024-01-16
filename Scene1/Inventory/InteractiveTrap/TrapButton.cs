using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapButton : MonoBehaviour
{
    [SerializeField]
    private GameObject ActiveTrapObj;

    public float pushTime = 0f;//누르는 시간
    public float onTime = 1.0f; //1초

    public float offTime = 1f; //꺼지는 시간.
    public float delayTime = 3.0f;

    public Sprite OnImage;
    public Sprite OffImage;
    SpriteRenderer myRenderer;
    
    private bool OnBtn = false;
 

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            delayTime = 0;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pushTime += Time.deltaTime;

            if (pushTime >= onTime)
            {
                Debug.Log("시간이" + onTime + "초 이상 흘렀다면,");
                OnBtn = true;

            }

        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pushTime = 0; //플레이어가 이 콜라이더 범위에서 벌어졌을때, 누르는 시간 초기화.

            delayTime = offTime; //delay 시간이 지나면 = 꺼지는 시간이 된다.
        }
    }

    void Update()
    {
        if (delayTime > 0) 
        {
            delayTime -= Time.deltaTime;

            if(delayTime <= 0) 
            {
                delayTime = 0;
                OnBtn = false;
            }
        }

        if (OnBtn) 
        {
            myRenderer.sprite = OnImage;
            ActiveTrapObj.SetActive(true);
        }
        else if(!OnBtn)
        {
            myRenderer.sprite = OffImage;
            ActiveTrapObj.SetActive(false);

        }
    }


}
