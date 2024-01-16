using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPpotion : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // 회전 속도

    void Update() 
    {
        // Z 축을 중심으로 스프라이트 회전
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


