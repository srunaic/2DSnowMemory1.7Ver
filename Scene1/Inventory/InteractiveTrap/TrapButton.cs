using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapButton : MonoBehaviour
{
    [SerializeField]
    private GameObject ActiveTrapObj;

    public float pushTime = 0f;//������ �ð�
    public float onTime = 1.0f; //1��

    public float offTime = 1f; //������ �ð�.
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
                Debug.Log("�ð���" + onTime + "�� �̻� �귶�ٸ�,");
                OnBtn = true;

            }

        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            pushTime = 0; //�÷��̾ �� �ݶ��̴� �������� ����������, ������ �ð� �ʱ�ȭ.

            delayTime = offTime; //delay �ð��� ������ = ������ �ð��� �ȴ�.
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
