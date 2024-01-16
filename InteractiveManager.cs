using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : MonoBehaviour
{
    public Interactable selectObject; //선택된 오브젝트
    public KeyCode inputKey = KeyCode.Z;

    void Update()
    {
        //지정된 키를 확인하는 if
        if (Input.GetKeyDown(inputKey))
        {
            UseSelectObject();
        }
    }

    public void UseSelectObject()
    {

        if (selectObject != null)
        {
            //작동내용.
            Debug.Log("상호작용했다.");
            selectObject.Interact(gameObject);//player 매게변수  Interactive의 player 객체를 들고옴.
        }
        else
        {
            Debug.Log("사용할 오브젝트가 없음");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactable>
            (out Interactable item)) //상호작용 될 객체들은 item ex) Door window 등 무기 포함.
        {
            selectObject = item;

            if (selectObject.UseDirect)
            {
                selectObject.Interact(gameObject);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactable>
            (out Interactable item))
        {
            //지금 떨어진 물체가 마지막으로 닿은 물체인 경우에만 -> null처리
            if (item == selectObject)
                selectObject = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactable>
            (out Interactable item))
        {
            selectObject = item;

            if (selectObject.UseDirect)
            {
                selectObject.Interact(gameObject);

            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactable>
            (out Interactable item))
        {
            selectObject = item;

            if (selectObject.UseDirect)
            {
                selectObject.Interact(gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactable>
            (out Interactable item))
        {
            //지금 떨어진 물체가 마지막으로 닿은 물체인 경우에만 -> null처리
            if (item == selectObject)
                selectObject = null;
        }
    }
}
