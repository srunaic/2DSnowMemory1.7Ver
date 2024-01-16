using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animator ChinemaCam;//연출 카메라 애니메이터.

    public void ChinemaCameraEffect()
    {
        ChinemaCam.GetComponent<Animator>();
    }
}
