using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGazer : MonoBehaviour
{
    public float speed = 5.0f; // 유성우의 속도
   // public float rotationSpeed = 3.0f;
    public Vector2 direction = new Vector2(-20, -20); // 대각선 방향

    private void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
       // transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }



}
   

