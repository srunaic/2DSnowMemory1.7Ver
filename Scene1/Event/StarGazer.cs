using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGazer : MonoBehaviour
{
    public float speed = 5.0f; // �������� �ӵ�
   // public float rotationSpeed = 3.0f;
    public Vector2 direction = new Vector2(-20, -20); // �밢�� ����

    private void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
       // transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }



}
   

