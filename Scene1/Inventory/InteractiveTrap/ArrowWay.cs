using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWay : MonoBehaviour
{
    [Header("방향지시등 타겟 지정형 Arrow객체.")]
    public Transform target; 
    public float arrivalDistance = 1f; //일정 거리 이상 멀어지는지.
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
