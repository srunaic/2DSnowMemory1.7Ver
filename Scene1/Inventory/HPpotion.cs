using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPpotion : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // ȸ�� �ӵ�

    void Update() 
    {
        // Z ���� �߽����� ��������Ʈ ȸ��
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {

           Destroy(gameObject,0.2f);

        }

    }

}


