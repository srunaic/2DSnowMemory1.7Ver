using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingItem2 : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // 회전 속도
    public GameObject Flying;//실질적 보이는 날개 오브젝트 플레이어에 달려있음.
    public bool OnFlying; //날개를 가지고 있는 상태인지.
    public LanaPlayer player;
    void Update()
    {
        // Z 축을 중심으로 스프라이트 회전
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            OnFlying = true;
            AirItemDestroy();
        }

    }
    public void AirItemDestroy()
    {
        if (OnFlying)
        {
            gameObject.SetActive(false);//파밍 아이템 1회용 아이템 개체 제거.
            Flying.SetActive(true); //플라이여 살아나라.

        }
    }

    public void FlyingItemRemove() //특정 조건에서 발생함.
    {
        OnFlying = false;
        Destroy(Flying, 1f);// 이 함수를 LanaPlayer에서 delay 발생시 실행. 지속시간 지난 후 개체 파괴.
        player.flyItemDelay = 0;//0 초기화.
    }
}
