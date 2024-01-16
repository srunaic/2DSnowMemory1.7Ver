using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // LanaPlayer The character's Transform to follow

    void LateUpdate()
    {
        if (target == null) 
            return;

        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

    

        // 투명화 처리는 TransparentObject 스크립트에서 이미 수행됩니다.
        // TransparentObject 스크립트가 자체적으로 투명화를 관리하므로 FollowCamera에서 직접 처리할 필요는 없습니다.
    }
}
