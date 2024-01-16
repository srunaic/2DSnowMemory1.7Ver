using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveManager : MonoBehaviour
{
    public Interactable selectObject; //���õ� ������Ʈ
    public KeyCode inputKey = KeyCode.Z;

    void Update()
    {
        //������ Ű�� Ȯ���ϴ� if
        if (Input.GetKeyDown(inputKey))
        {
            UseSelectObject();
        }
    }

    public void UseSelectObject()
    {

        if (selectObject != null)
        {
            //�۵�����.
            Debug.Log("��ȣ�ۿ��ߴ�.");
            selectObject.Interact(gameObject);//player �ŰԺ���  Interactive�� player ��ü�� ����.
        }
        else
        {
            Debug.Log("����� ������Ʈ�� ����");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Interactable>
            (out Interactable item)) //��ȣ�ۿ� �� ��ü���� item ex) Door window �� ���� ����.
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
            //���� ������ ��ü�� ���������� ���� ��ü�� ��쿡�� -> nulló��
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
            //���� ������ ��ü�� ���������� ���� ��ü�� ��쿡�� -> nulló��
            if (item == selectObject)
                selectObject = null;
        }
    }
}
