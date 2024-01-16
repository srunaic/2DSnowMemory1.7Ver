using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityMap : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)//이 스크립트는 무한맵 적용할 이미지에 넣어야한다.
    {
        if (!collision.CompareTag("Area")) //그 지역이 아닐때,
            return;

        // 거리를 구하기 위해 플레이어 위치와 타일맵 위치를 미리 저장.

        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        Vector3 playerDir = GameManager.Instance.player.inputVec;
        float diffx = Mathf.Abs(dirX);
        float diffy = Mathf.Abs(dirY);

        dirX = playerDir.x > 0 ? 1 : -1;
        dirY = playerDir.y > 0 ? 1 : -1;


        switch (transform.tag)
        {
            case "Ground":
                if (diffx > diffy)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffx < diffy)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;

                /*case "Enemy":
                    if (coll.enabled)
                    {
                        transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                    }
                    break;
             }
               */
        }
    }
}





