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

    

        // ����ȭ ó���� TransparentObject ��ũ��Ʈ���� �̹� ����˴ϴ�.
        // TransparentObject ��ũ��Ʈ�� ��ü������ ����ȭ�� �����ϹǷ� FollowCamera���� ���� ó���� �ʿ�� �����ϴ�.
    }
}
