using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWay : MonoBehaviour
{
    [Header("�������õ� Ÿ�� ������ Arrow��ü.")]
    public Transform target; 
    public float arrivalDistance = 1f; //���� �Ÿ� �̻� �־�������.
    public LanaPlayer player;


    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.right = direction;

            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (distanceToTarget <= arrivalDistance)
            {

                gameObject.SetActive(false);
            }

                  
        }
        
    }
}
